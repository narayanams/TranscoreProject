using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.Models
{
    public class ErrorResponseMessages
    {

        public ErrorResponseMessages()
        {
            MessageType = string.Empty;
            ErrorResponseMessage = string.Empty;
            MessageProcessStatus = true;
            
        }

        public string MessageType { get; set; }
        public string ErrorResponseMessage { get; set; }

        public string MessageValidation { get; set; }

        public string SentToRabbitMQ { get; set; }

        public string RequestMessage { get; set; }
        public string ResponseMessage { get; set; }
        public bool MessageProcessStatus { get; set; }
    }
}
