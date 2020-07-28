using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction
{
    public static class ConnectionConstants
    {
        //public const string HostName = "209.105.248.50";
        //public const string QueueName = "TPQueue1";

        public const string HostName = "10.251.9.80";
        public const string QueueName = "crm_resp";
        public const string UserName = "crm";
        public const string Password = "crm";
        public const int Port = 5672;
        public const string VirtualHost = "crm";
        public const string Exchange = "crm.cfx";


    }
}
