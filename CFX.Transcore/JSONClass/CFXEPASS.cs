using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallSPFromAzureFunction.JSONClass
{
    public class CFXEPASS
    {
        public string TagNumber { get; set; }
        public string IssuingAuthority { get; set; }
        public string StateCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountStatusCurrent { get; set; }
        public string AccountStatusAtTrans { get; set; }
        public string RevNonRevType { get; set; }
    }
}