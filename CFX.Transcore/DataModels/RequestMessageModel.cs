using System;
using System.Collections.Generic;
using System.Text;

namespace CFXTranscoreProjects.DataModels
{
	public class RequestMessageModel
	{
		public string TagNumber { get; set; }
		public string IssuingAuthority { get; set; }
		public string StateCode { get; set; }
		public string LicensePlate { get; set; }
		public string LicenseState { get; set; }
		public string AccountNumber { get; set; }		
		public string ICLAckDate { get; set; }
		public string ICLPAckEndDate { get; set; }
		public string TransDateTime { get; set; }
	}
}
