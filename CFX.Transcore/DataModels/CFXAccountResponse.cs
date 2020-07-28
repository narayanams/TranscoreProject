using System;
using System.Collections.Generic;
using System.Text;

namespace CFXTranscoreProjects.DataModels
{
    public class CFXAccountResponse
    {
        public CFXAccountResponse()
        {
            AccountNumber = string.Empty;
            AccountStatus = string.Empty;
            AccountStatusAtTransaction = string.Empty;
            TagNumber = string.Empty;
            IssuingAuthority = string.Empty;
            StateCode = string.Empty;
            RevNonRevType = string.Empty;
            IssuingAuthorityCode = string.Empty;

            Errors = string.Empty;
        }

        public string AccountNumber { get; set; }
        public string AccountStatus { get; set; }
        public string AccountStatusAtTransaction { get; set; }

        public string TagNumber { get; set; }
        public string IssuingAuthority { get; set; }
        public string IssuingAuthorityCode { get; set; }
        public string StateCode { get; set; }
        public string RevNonRevType { get; set; }
        public string Errors { get; set; }
    }
}
