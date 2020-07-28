using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.DAL.CustomExceptions
{
    public class CircuitBreakerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitBreakerException"/> class.
        /// </summary>
        public CircuitBreakerException() : base(ErrorMessages.ServiceTemporarilyDown)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitBreakerException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public CircuitBreakerException(string message) : base(message)
        {
        }
    }
}
