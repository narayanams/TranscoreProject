using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.Models
{
    public class ResponseMessage
    {

        public ResponseMessage()
        {
            Error = string.Empty;
            JSONMessage = string.Empty;
        }

        public string Error { get; set; }
        public string JSONMessage { get; set; }
    }
}
