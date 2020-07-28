

namespace CallSPFromAzureFunction
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines the <see cref="CircuitBreakerPatternConstants" />
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class CircuitBreakerPatternConstants
    {
        /// <summary>
        /// Defines the InitialTimespanDifference
        /// </summary>
        public static readonly long InitialTimespanDifference = DateTime.UtcNow.Ticks - DateTime.MinValue.Ticks;

        /// <summary>
        /// Defines the MaximumTimeDifferenceToResetCircuitBreaker
        /// </summary>
        public static readonly long MaximumTimeDifferenceToResetCircuitBreaker = new TimeSpan(0, 2, 0).Ticks;

        /// <summary>
        /// Defines the MinimumExceptionCounterToOpenCircuit
        /// </summary>
        public static readonly int MinimumExceptionCounterToOpenCircuit = 2;

        /// <summary>
        /// Defines the IncrementalDelayWhenRetrying
        /// </summary>
        public static readonly int IncrementalDelayWhenRetrying = 2000;

        /// <summary>
        /// Defines the MinimumTimeToTryClosingCircuit
        /// </summary>
        public static readonly long MinimumTimeToTryClosingCircuit = new TimeSpan(0, 0, 30).Ticks;

        /// <summary>
        /// Defines the MaximumNumberOfRetries
        /// </summary>
        public static readonly int MaximumNumberOfRetries = 3;
    }
}
