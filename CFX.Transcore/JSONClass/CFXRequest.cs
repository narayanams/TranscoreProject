using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallSPFromAzureFunction.JSONClass
{
    public class CFXRequest
    {

        public CFXRequest()
        {
            RequestType = string.Empty;
            RequestId = string.Empty;
            AccountNumber = string.Empty;
            RequestDate = string.Empty;
            TransDateTime = string.Empty;
            LicensePlate = string.Empty;
            LicenseState = string.Empty;
        }

        public string RequestType { get; set; }
        public string RequestId { get; set; }

        public string AccountNumber { get; set; }
        public string RequestDate { get; set; }
        public string TransDateTime { get; set; }
        public string LicensePlate { get; set; }
        public string LicenseState { get; set; }
    }
}