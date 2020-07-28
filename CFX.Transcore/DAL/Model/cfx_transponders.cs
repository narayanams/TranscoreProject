using System;
using System.Collections.Generic;
using System.Text;


namespace CallSPFromAzureFunction.DAL.Models
{
    public class cfx_transponders
    {
        /// <summary>
        /// Gets or sets the cfx_name
        /// </summary>
        public string cfx_name { get; set; }

        /// <summary>
        /// Gets or sets the cfx_accountid
        /// </summary>
        public Accounts cfx_accountid { get; set; }

        /// <summary>
        /// Gets or sets the cfx_transpondertypeid
        /// </summary>
        public cfx_transpondertypes cfx_transpondertypeid { get; set; }

        /// <summary>
        /// Gets or sets the cfx_transpondertype
        /// </summary>
        public int? cfx_transpondertype { get; set; }

        /// <summary>
        /// Gets or sets the UPDATEstatuscode
        /// </summary>
        public long? statuscode { get; set; }

        /// <summary>
        /// This property is to expose status as enumeration which comes as long value from Dynamics
        /// </summary>
        //public cfx_transponder_statuscode TransponderStatus
        //{
        //    get { return statuscode == null || statuscode == 0 ? cfx_transponder_statuscode.Verify : (cfx_transponder_statuscode)statuscode; }
        //    set { statuscode = (long)value; }
        //}

        /// <summary>
        /// Gets or sets the statecode
        /// </summary>
        public int? statecode { get; set; }

        /// <summary>
        /// Gets or sets a value of cfx_description
        /// </summary>
        public string cfx_description { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isallowparking
        /// </summary>
        public bool cfx_isallowparking { get; set; }

        /// <summary>
        /// Gets or sets the cfx_transponderid
        /// </summary>
        public Guid cfx_transponderid { get; set; }

        /// <summary>
        /// Associates a transponder to its vehicle's class. Reference is removed if transponder is returned
        /// </summary>
     //   public cfx_vehicleclass cfx_vehicleclassid { get; set; }

        /// <summary>
        /// Date value set when transponder status has been modified, including returns
        /// </summary>
        public DateTime? cfx_transponderstatusupdatedon { get; set; }

        /// <summary>
        /// Staff member who last updated this transponder, including returns
        /// </summary>
      //  public SystemUser cfx_transponderstatusupdatedby { get; set; }

        /// <summary>
        /// Gets or sets the cfx_transponderstatus value (not the label)
        /// </summary>
        public long? cfx_transponderstatus { get; set; }
        public long cfx_revenuetypecode { get; set; }
        public cfx_agency cfx_agencyid { get; set; }
    }
}
