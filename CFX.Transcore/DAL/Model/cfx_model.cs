using System;
using System.Collections.Generic;
using System.Text;


namespace CallSPFromAzureFunction.DAL.Models
{
    public class cfx_model
    {
        public Guid cfx_modelid { get; set; }

        /// <summary>
        /// Gets or sets the cfx_name
        /// </summary>
        public string cfx_name { get; set; }

        /// <summary>
        /// Gets or sets the cfx_makeid
        /// </summary>
        public cfx_make cfx_makeid { get; set; }
    }
}
