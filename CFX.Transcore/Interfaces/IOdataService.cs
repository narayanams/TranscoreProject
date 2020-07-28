using System;
using System.Collections.Generic;
using System.Text;
using Simple.OData.Client;

namespace CallSPFromAzureFunction.Interfaces
{
    public interface IOdataService
    {
        IODataClient GetDynamicsCEClient();
        IODataClient GetDynamicsFOClient();
        void ResetOdataCache();


    }
}
