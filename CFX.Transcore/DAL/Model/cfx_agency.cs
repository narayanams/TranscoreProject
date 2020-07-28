using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.DAL.Models
{
    public class cfx_agency
    {
        public string cfx_name { get; set; }
        public string cfx_agencyid { get; set; }

        public string cfx_agencycode { get; set; }

        public string cfx_agencykey { get; set; }

        public cfx_state cfx_stateid { get; set; }

        public cfx_state _cfx_stateid_value { get; set; }
    }
}
