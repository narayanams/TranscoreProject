using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallSPFromAzureFunction.JSONClass
{
    public class CFXResponse
    {
        public string RequestID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public string AccountName { get; set; }
        public CFXEPASS EPASS { get; set; }
    }
}