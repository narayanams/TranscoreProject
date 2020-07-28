using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.Transcore
{
    public class Metadata
    {
        public string RbaSqn { get; set; }
        public string AuditSessionId { get; set; }
        public string TableSpace { get; set; }
        public string CURRENTSCN { get; set; }
        public string SQLRedoLength { get; set; }
        public string BytesProcessed { get; set; }
        public string ParentTxnID { get; set; }
        public string SessionInfo { get; set; }
        public string RecordSetID { get; set; }
        public string DBCommitTimestamp { get; set; }
        public string COMMITSCN { get; set; }
        public string SEQUENCE { get; set; }
        public string Rollback { get; set; }
        public string STARTSCN { get; set; }
        public string SegmentName { get; set; }
        public string OperationName { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TxnUserID { get; set; }
        public string RbaBlk { get; set; }
        public string SegmentType { get; set; }
        public string TableName { get; set; }
        public string TxnID { get; set; }
        public string Serial { get; set; }
        public string ThreadID { get; set; }
        public DateTime COMMIT_TIMESTAMP { get; set; }
        public string OperationType { get; set; }
        public string ROWID { get; set; }
        public string DBTimeStamp { get; set; }
        public string TransactionName { get; set; }
        public string SCN { get; set; }
        public string Session { get; set; }
    }

    public class Data
    {
        public string REQUEST_TYPE { get; set; }
        public string CRM_REQUEST_ID { get; set; }
        public string REQUESTOR { get; set; }
        public DateTime REQUEST_DATE { get; set; }
        public DateTime TRANS_DATE_TIME { get; set; }
        public string REQUEST_MESSAGE { get; set; }
    }

    public class RootObject
    {
        public Metadata metadata { get; set; }
        public Data data { get; set; }
        public object before { get; set; }
        public object userdata { get; set; }

        public string Errors { get; set; }
    }
}
