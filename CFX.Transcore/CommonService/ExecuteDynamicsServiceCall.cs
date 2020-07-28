using CallSPFromAzureFunction.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using CallSPFromAzureFunction.DAL.CustomExceptions;


namespace CallSPFromAzureFunction.CommonService
{
    public class ExecuteDynamicsServiceCall : IExecuteDynamicsServiceCall
    {
        /// <summary>
        /// Defines the circuitBreakerStateCollection
        /// </summary>
        internal ConcurrentDictionary<string, CircuitBreakerState> circuitBreakerStateCollection;

        /// <summary>
        /// Defines the logger
        /// </summary>
        private readonly ILogger<ExecuteDynamicsServiceCall> logger;

        /// <summary>
        /// Defines the defaultCircuitBreakerStateCollection
        /// </summary>
        private readonly CircuitBreakerState defaultCircuitBreakerStateCollection;

        /// <summary>
        /// Defines the odataService
        /// </summary>
        private readonly IOdataService odataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecuteDynamicsServiceCall"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{ExecuteDynamicsServiceCall}"/></param>
        /// <param name="odataService">The odataService<see cref="IOdataService"/></param>
        public ExecuteDynamicsServiceCall(ILogger<ExecuteDynamicsServiceCall> logger, IOdataService odataService)
        {
            this.logger = logger;
            this.odataService = odataService;
            circuitBreakerStateCollection = new ConcurrentDictionary<string, CircuitBreakerState>();
            defaultCircuitBreakerStateCollection = new CircuitBreakerState
            {
                ExceptionsCounter = 0,
                ODataExceptionsCounter = 0,
                IsClosed = true,
                LastExceptionOccuredTime = DateTime.MinValue.Ticks,
                TimespanDifferenceBetweenExceptions = CircuitBreakerPatternConstants.InitialTimespanDifference
            };
        }

        /// <summary>
        /// The ExecuteServiceCall
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The func<see cref="Func{Task{T}}"/></param>
        /// <param name="serviceName">The serviceName<see cref="string"/></param>
        /// <returns>The <see cref="Task{T}"/></returns>
        public async Task<T> ExecuteServiceCall<T>(Func<Task<T>> func, string serviceName = null)
        {
            try
            {
                if (serviceName == null)
                {
                    return await this.TryWebCallWithRetry(func);
                }
                else
                {
                    CircuitBreakerState circuitBreakerState;
                    this.circuitBreakerStateCollection.TryGetValue(serviceName, out circuitBreakerState);
                    if (circuitBreakerState == null)
                    {
                        circuitBreakerStateCollection.TryAdd(serviceName, defaultCircuitBreakerStateCollection);
                        this.circuitBreakerStateCollection.TryGetValue(serviceName, out circuitBreakerState);
                    }

                    CircuitBreakerState newCircuitBreakerState = new CircuitBreakerState
                    {
                        ExceptionsCounter = circuitBreakerState.ExceptionsCounter,
                        ODataExceptionsCounter = circuitBreakerState.ODataExceptionsCounter,
                        IsClosed = circuitBreakerState.IsClosed,
                        LastExceptionOccuredTime = circuitBreakerState.LastExceptionOccuredTime,
                        TimespanDifferenceBetweenExceptions = circuitBreakerState.TimespanDifferenceBetweenExceptions
                    };

                    if (newCircuitBreakerState.IsClosed)
                    {
                        try
                        {
                            return await this.TryWebCallWithRetry(func);
                        }
                        catch (Microsoft.OData.ODataException oDataException)
                        {
                            this.logger.LogError(oDataException, $"{serviceName} has thrown an OData Exception");

                            newCircuitBreakerState.ODataExceptionsCounter += 1;
                            this.UpdateCircuitBreakerState(newCircuitBreakerState);

                            ///TODO - In case we want to clear metadata cache after 4 failures for ANY api, we need to refactor the below dictionary entry to separately save a metadata cache exception state.
                            if (newCircuitBreakerState.TimespanDifferenceBetweenExceptions > CircuitBreakerPatternConstants.MaximumTimeDifferenceToResetCircuitBreaker)
                            {
                                newCircuitBreakerState.ODataExceptionsCounter = 0;
                                this.circuitBreakerStateCollection.TryUpdate(serviceName, newCircuitBreakerState, circuitBreakerState);
                                throw;
                            }
                            else if (newCircuitBreakerState.ODataExceptionsCounter > CircuitBreakerPatternConstants.MinimumExceptionCounterToOpenCircuit)
                            {
                                this.logger.LogError(oDataException, $"{serviceName} {ErrorMessages.MethodInOpenState}");
                                this.odataService.ResetOdataCache();
                                newCircuitBreakerState.IsClosed = false;
                            }
                            else
                            {
                                this.circuitBreakerStateCollection.TryUpdate(serviceName, newCircuitBreakerState, circuitBreakerState);
                                throw;
                            }
                        }
                        catch (Exception ex)
                        {
                            this.logger.LogError(ex, $"{serviceName} {ErrorMessages.MethodThrewAnException}", ex.Message);

                            newCircuitBreakerState.ExceptionsCounter += 1;
                            this.UpdateCircuitBreakerState(newCircuitBreakerState);

                            if (newCircuitBreakerState.TimespanDifferenceBetweenExceptions > CircuitBreakerPatternConstants.MaximumTimeDifferenceToResetCircuitBreaker)
                            {
                                newCircuitBreakerState.ExceptionsCounter = 0;
                                this.circuitBreakerStateCollection.TryUpdate(serviceName, newCircuitBreakerState, circuitBreakerState);
                                throw;
                            }
                            else if (newCircuitBreakerState.ExceptionsCounter > CircuitBreakerPatternConstants.MinimumExceptionCounterToOpenCircuit)
                            {
                                this.logger.LogError(ex, $"{serviceName} {ErrorMessages.MethodInOpenState}");

                                newCircuitBreakerState.IsClosed = false;
                            }
                            else
                            {
                                this.circuitBreakerStateCollection.TryUpdate(serviceName, newCircuitBreakerState, circuitBreakerState);
                                throw;
                            }
                        }
                    }
                    else
                    {
                        if (DateTime.UtcNow.Ticks - newCircuitBreakerState.LastExceptionOccuredTime > CircuitBreakerPatternConstants.MinimumTimeToTryClosingCircuit)
                        {
                            this.logger.LogInformation($"{serviceName} {ErrorMessages.MethodInHalfOpenState}");

                            try
                            {
                                var result = await this.TryWebCallWithRetry(func, 1);
                                newCircuitBreakerState.ExceptionsCounter = 0;
                                newCircuitBreakerState.ODataExceptionsCounter = 0;
                                newCircuitBreakerState.IsClosed = true;

                                this.circuitBreakerStateCollection.TryUpdate(serviceName, newCircuitBreakerState, circuitBreakerState);

                                this.logger.LogInformation($"{serviceName} {ErrorMessages.MethodReturnToClosedState}");

                                return result;
                            }
                            catch (Exception ex)
                            {
                                this.logger.LogError(ex, $"{serviceName} {ErrorMessages.MethodReturnToOpenState}", ex.Message);

                                newCircuitBreakerState.ExceptionsCounter += 1;
                                newCircuitBreakerState.ODataExceptionsCounter += 1;
                                newCircuitBreakerState.TimespanDifferenceBetweenExceptions = DateTime.UtcNow.Ticks - newCircuitBreakerState.LastExceptionOccuredTime;
                                newCircuitBreakerState.LastExceptionOccuredTime = DateTime.UtcNow.Ticks;
                            }
                        }
                        else
                        {
                            this.logger.LogError($"{serviceName} {ErrorMessages.MethodRunningInOpenState}");
                        }
                    }
                    this.circuitBreakerStateCollection.TryUpdate(serviceName, newCircuitBreakerState, circuitBreakerState);
                }
            }
            catch (InvalidOperationException ex) //For catching dictionary exceptions in case of threading issues (concurrent read/write operations)
            {
                this.logger.LogError(ex, $"{serviceName} {ErrorMessages.InvalidOperationException}", ex.Message);

                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"{serviceName} {ErrorMessages.GeneralException}", ex.Message);

                throw;
            }
            throw new CircuitBreakerException();
        }

        /// <summary>
        /// The UpdateCircuitBreakerState
        /// </summary>
        /// <param name="newCircuitBreakerState">The newCircuitBreakerState<see cref="CircuitBreakerState"/></param>
        private void UpdateCircuitBreakerState(CircuitBreakerState newCircuitBreakerState)
        {
            newCircuitBreakerState.TimespanDifferenceBetweenExceptions = DateTime.UtcNow.Ticks - newCircuitBreakerState.LastExceptionOccuredTime;
            newCircuitBreakerState.LastExceptionOccuredTime = DateTime.UtcNow.Ticks;
        }

        /// <summary>
        /// The TryWebCallWithRetry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The func<see cref="Func{Task{T}}"/></param>
        /// <param name="maximumRetries">The maximumRetries<see cref="int"/></param>
        /// <returns>The <see cref="Task{T}"/></returns>
        private async Task<T> TryWebCallWithRetry<T>(Func<Task<T>> func, int maximumRetries = 3)
        {
            int retry = 0;
            int delay = 0;

            while (true)
            {
                try
                {
                    return await func();
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, string.Format(ErrorMessages.RetryAfterException, func.ToString()), ex.Message);
                    retry++;
                    if (retry >= maximumRetries)
                    {
                        throw;
                    }
                }

                delay += CircuitBreakerPatternConstants.IncrementalDelayWhenRetrying;
                await Task.Delay(delay);
            }
        }
    }
}
