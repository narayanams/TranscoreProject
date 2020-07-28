using System;
using System.Collections.Generic;
using System.Text;


namespace CallSPFromAzureFunction.DAL.Models
{
    
        public class cfx_vehicle
        {
            /// <summary>
            /// Gets or sets the Account lookup reference
            /// </summary>
            public Accounts cfx_accountid { get; set; }

            /// <summary>
            /// Gets or sets the cfx_transponderid
            /// </summary>
            public cfx_transponders cfx_transponderid { get; set; }

            /// <summary>
            /// Gets or sets the cfx_alias
            /// </summary>
            public string cfx_alias { get; set; }

            /// <summary>
            /// Gets or sets the Make lookup reference
            /// </summary>
            public cfx_make cfx_makeid { get; set; }

            /// <summary>
            /// Gets or sets the Model lookup reference
            /// </summary>
            public cfx_model cfx_modelid { get; set; }

            /// <summary>
            /// Gets or sets the cfx_year
            /// </summary>
            public int? cfx_year { get; set; }

            /// <summary>
            /// Gets or sets the Year 2
            /// </summary>
            public string cfx_year2 { get; set; }

            /// <summary>
            /// Gets or sets the Color Code
            /// </summary>
            public long? cfx_colorcode { get; set; }

            /// <summary>
            /// Gets or sets the License Plate number
            /// </summary>
            public string cfx_name { get; set; }

            /// <summary>
            /// Gets or sets the State lookup reference
            /// </summary>
            public cfx_state cfx_licenseplatestateid { get; set; }

            /// <summary>
            /// Gets or sets the License Plate Type Code
            /// </summary>
            public long? cfx_licenseplatetypecode { get; set; }

            /// <summary>
            /// Gets or sets the cfx_vehicleid
            /// </summary>
            public Guid cfx_vehicleid { get; set; }

            /// <summary>
            /// Gets or sets the modifiedon
            /// </summary>
            public DateTime? modifiedon { get; set; }

            /// <summary>
            /// Gets or sets the cfx_effectiveenddate
            /// </summary>
            public DateTime? cfx_effectiveenddate { get; set; }

            /// <summary>
            /// Gets or sets the cfx_effectivestartdate
            /// </summary>
            public DateTime? cfx_effectivestartdate { get; set; }
        }
    
}
