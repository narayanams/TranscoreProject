using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction
{
    public class MessageLogModel
    {

        public MessageLogModel()
        {
            RequestID = 0;
            InMessage = string.Empty;
            Response = string.Empty;
            Request = string.Empty;
            ErrorMessage = string.Empty;
        }

        public int RequestID { get; set; }

        public int RequestType { get; set; }

        public string InMessage { get; set; }
        public string Response { get; set; }
        public string Request { get; set; }
        public string ErrorMessage { get; set; }
    }
}
