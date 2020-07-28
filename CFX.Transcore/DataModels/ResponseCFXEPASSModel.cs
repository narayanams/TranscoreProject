using System;
using System.Collections.Generic;
using System.Text;

namespace CFXTranscoreProjects.DataModels
{
	public class ResponseCFXEPASSModel
	{
        public string TagNumber { get; set; }
        public string IssuingAuthority { get; set; }
        public string StateCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountStatusCurrent { get; set; }
        public string AccountStatusAtTrans { get; set; }
        public string RevNonRevType { get; set; }
        public string TagStatusCurrent { get; set; }
    }
}
