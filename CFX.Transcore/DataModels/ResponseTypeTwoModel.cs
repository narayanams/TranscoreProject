using System;
using System.Collections.Generic;
using System.Text;

namespace CFXTranscoreProjects.DataModels
{
	public class ResponseTypeTwoModel
	{
        public int RequestType { get; set; }
        public int RequestId { get; set; }
        public int Requestor { get; set; }
        public string RequestDate { get; set; }

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }


        public string AccountNumber { get; set; }
        public string AccountStatusCurrent { get; set; }
        public string AccountStatusAtTrans { get; set; }

        public ResponseCFXCHFPModel cfxEPASS { get; set; }
        public ResponseCFXTRPPModel cfxTRPP { get; set; }
        public ResponseCFXPOCHModel cfxPOCH { get; set; }
        public ResponseCFXCHPModel cfxCHP { get; set; }
    }
}
