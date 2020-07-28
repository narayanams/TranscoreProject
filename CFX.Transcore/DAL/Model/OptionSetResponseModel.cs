using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.DAL.Models
{
    public class OptionSetResponseModel
    {
        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}
