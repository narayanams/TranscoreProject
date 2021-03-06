﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CFXTranscoreProjects.DataModels
{
	public class ResponseTypeFourModel
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

        public ResponseCFXEPASSModel cfxEpassModel { get; set; }
        public ResponseCFXTRPPModel cfxTrppModel { get; set; }

        public ResponseCFXPOCHModel cfxPochModel { get; set; }

        public ResponseCFXCHPModel cfxCHPModel { get; set; }

        public string Errors { get; set; }

    }
}
