using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.StaticClasses
{
    public static class StaticVars
    {
        public static string SUCCESS = "SUCCESS";

        public static string DBConnectionString = "Server=tcp:sqlsimserver.database.windows.net,1433;Initial Catalog=TPMessages;Persist Security Info=False;User ID=sqlsimserver;Password=Orlando9876!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
