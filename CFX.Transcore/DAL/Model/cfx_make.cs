using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.DAL.Models
{
   
        public class cfx_make
        {
            /// <summary>
            /// Gets or sets the cfx_name
            /// </summary>
            public string cfx_name { get; set; }

            /// <summary>
            /// Gets or sets the cfx_makeid
            /// </summary>
            public Guid cfx_makeid { get; set; }

            /// <summary>
            /// Gets or sets the cfx_make_cfx_model_makeid
            /// </summary>
            public List<cfx_model> cfx_make_cfx_model_makeid { get; set; }
        }
  
}
