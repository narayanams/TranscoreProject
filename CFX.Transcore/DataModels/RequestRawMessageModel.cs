namespace CFXTranscoreProjects.DataModels
{
    using System;

    public class RequestRawMessageModel
	{
        public int REQUEST_TYPE { get; set; }

        public int CRM_REQUEST_ID { get; set; }

        public int REQUESTOR { get; set; }

        public string REQUEST_DATE { get; set; }

        public string TRANS_DATE_TIME { get; set; }

        public string REQUEST_MESSAGE { get; set; }

        public RequestMessageModel RequestMesssage { get; set; }
    }
}
