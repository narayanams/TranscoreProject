using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.Models
{
    public class ResponseModel<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether successful
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the results
        /// </summary>
        public T Results { get; set; }

        public List<string> messages { get; set; }
    }
}
