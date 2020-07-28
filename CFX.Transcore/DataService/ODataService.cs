using CallSPFromAzureFunction.Interfaces;
using Simple.OData.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CallSPFromAzureFunction.Secrets.Interfaces;


namespace CallSPFromAzureFunction.DataService
{
    public class ODataService : IOdataService
    {
        private IProxyService proxyService;


        private IKeyvaultProvider keyvaultProvider;

        public string Errors;




        public ODataService(IProxyService proxyService, IKeyvaultProvider keyvaultProvider)
        {
            this.proxyService = proxyService;
            this.keyvaultProvider = keyvaultProvider;
            Errors = string.Empty;
        }


        public IODataClient GetDynamicsCEClient()
        {
            try
            {
                // string apiEndpoint = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsApiEndpoint) + Constants.DynamicsCEDataEndpointSuffix;
                string apiEndpoint = string.Empty;
                var token = Task.Run(async () => { return await this.proxyService.GetDynamicsCEToken(); }).Result;
                return SetOdataSettingsAndReturnClient(apiEndpoint, token);
            }
            catch (Exception ex)
            {
                Errors = ex.Message.ToString();
                return null;
            }
        }


        public IODataClient GetDynamicsFOClient()
        {
            string apiEndpoint = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsFOApiEndpoint) + Constants.DynamicsFODataEndpointSuffix;
            var token = Task.Run(async () => { return await this.proxyService.GetDynamicsFOToken(); }).Result;
            return SetOdataSettingsAndReturnClient(apiEndpoint, token);
        }


        private static IODataClient SetOdataSettingsAndReturnClient(string apiEndpoint, string token)
        {
            string apiEndPoint = "https://cfxdev.api.crm.dynamics.com/";
            apiEndPoint = apiEndPoint + "api/data/v9.1/";

            var settings = new ODataClientSettings(new Uri(apiEndpoint));
            settings.BeforeRequest += delegate (HttpRequestMessage message)
            {
                message.Headers.Add("Authorization", "Bearer " + token);
            };
            var client = new ODataClient(settings);
            return client;
        }


        public void ResetOdataCache()
        {
            ODataClient.ClearMetadataCache();
        }
    }
}
