using System;
using System.Collections.Generic;
using System.Text;

namespace CFXTranscoreProjects.DataModels
{
	public class ResponseCFXCHFPModel
	{
		public string TagNumber { get; set; }
		public string IssuingAuthority { get; set; }
		public string StateCode { get; set; }
		public string AccountNumber { get; set; }
		public string AccountStatusAtTrans { get; set; }
	}
}
