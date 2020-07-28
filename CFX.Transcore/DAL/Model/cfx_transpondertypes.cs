using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.DAL.Models
{
    public class cfx_transpondertypes
    {
        public bool cfx_activate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cfx_available
        /// </summary>
        public bool cfx_available { get; set; }

        /// <summary>
        /// Gets or sets the cfx_image
        /// </summary>
        public string cfx_image { get; set; }

        /// <summary>
        /// Gets or sets the cfx_longdescription
        /// </summary>
        public string cfx_longdescription { get; set; }

        /// <summary>
        /// Gets or sets the cfx_name
        /// </summary>
        public string cfx_name { get; set; }

        /// <summary>
        /// Gets or sets the cfx_shortdescription
        /// </summary>
        public string cfx_shortdescription { get; set; }

        /// <summary>
        /// Gets or sets the cfx_tax
        /// </summary>
        public decimal cfx_tax { get; set; }

        /// <summary>
        /// Gets or sets the transponder_type
        /// </summary>
        public string transponder_type { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can_buy
        /// </summary>
        public bool can_buy { get; set; }

        /// <summary>
        /// Gets or sets the shipping_time
        /// </summary>
        public string shipping_time { get; set; }
    }
}
