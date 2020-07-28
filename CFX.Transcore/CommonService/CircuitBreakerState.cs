

namespace CallSPFromAzureFunction.CommonService
{
    using System.Diagnostics.CodeAnalysis;

   
    [ExcludeFromCodeCoverage]
    internal class CircuitBreakerState
    {
       
        public bool IsClosed { get; set; }

        
        public int ExceptionsCounter { get; set; }

        
        public int ODataExceptionsCounter { get; set; }

       
        public long LastExceptionOccuredTime { get; set; }

       
        public long TimespanDifferenceBetweenExceptions { get; set; }
    }
}
