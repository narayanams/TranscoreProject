

namespace CallSPFromAzureFunction
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines the <see cref="ErrorMessages" />
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ErrorMessages
    {
        /// <summary>
        /// Defines the CircuitBreakerImplementationError
        /// </summary>
        public const string CircuitBreakerImplementationError = "Circuit Breaker Pattern cannot be implemented as the state has not been initialized.";

        /// <summary>
        /// Defines the ServiceTemporarilyDown
        /// </summary>
        public const string ServiceTemporarilyDown = "Service is temporaily down.";

        /// <summary>
        /// Defines the MethodThrewAnException
        /// </summary>
        public const string MethodThrewAnException = "method threw an exception.";

        /// <summary>
        /// Defines the MethodInOpenState
        /// </summary>
        public const string MethodInOpenState = "method has entered Open Circuit state.";

        /// <summary>
        /// Defines the MethodInHalfOpenState
        /// </summary>
        public const string MethodInHalfOpenState = "method has entered Half Open Circuit state and retrying the web call.";

        /// <summary>
        /// Defines the MethodReturnToClosedState
        /// </summary>
        public const string MethodReturnToClosedState = "method has entered Closed Circuit state and is up and running now.";

        /// <summary>
        /// Defines the MethodReturnToOpenState
        /// </summary>
        public const string MethodReturnToOpenState = "method has entered Open Circuit state as the calls failed while in half open state.";

        /// <summary>
        /// Defines the MethodRunningInOpenState
        /// </summary>
        public const string MethodRunningInOpenState = "method is in Open Circuit state and not trying web calls";

        /// <summary>
        /// Defines the InvalidOperationException
        /// </summary>
        public const string InvalidOperationException = "method threw an Invalid Operation Exception";

        /// <summary>
        /// Defines the GeneralException
        /// </summary>
        public const string GeneralException = "method threw an exception";

        /// <summary>
        /// Defines the RetryAfterException
        /// </summary>
        public const string RetryAfterException = "Retrying web call {0} because exception was thrown.";

        /// <summary>
        /// Defines the InvalidAccountNumber
        /// </summary>
        public const string InvalidAccountNumber = "Account number does not exist";

        /// <summary>
        /// Defines the InvalidCreditCardType
        /// </summary>
        public const string InvalidCreditCardType = "Credit card type does not exist";

        /// <summary>
        /// Defines the OptionSetNotFoundInDynamics
        /// </summary>
        public const string OptionSetNotFoundInDynamics = "Option Set {0} not found in Dynamics";

        /// <summary>
        /// Defines the NoOptionSetsNotFoundInDynamics
        /// </summary>
        public const string NoOptionSetsNotFoundInDynamics = "No Option Sets found in Dynamics";

        /// <summary>
        /// Defines the NoExistingPaymentTypeFound
        /// </summary>
        public const string NoExistingPaymentTypeFound = "Payment type cannot be updated as this account is not linked with any payment type";
    }
}
