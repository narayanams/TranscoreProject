using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Azure.Identity;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Simple.OData.Client;

namespace CallSPFromAzureFunction.StaticClasses
{
    public static class ConnectionClass
    {
        public static async Task<string> GetAccessToken()
        {
            string applicationId = "fa9f4554-c699-40c6-b81a-2a06356f7cd8";
            string clientSecret = "M*0eS]lC:2nE.ffNhHwIA3S7@fQYbXZ-";
            string aadInstanceUrl = "https://login.microsoftonline.com";
            string tenantId = "fdb3d149-830c-485d-a60f-caf3ce704d58";
            string organizationUrl = "https://cfxdev.api.crm.dynamics.com/";


            var clientcred = new ClientCredential(applicationId, clientSecret);
            //var authenticationContext = new AuthenticationContext($"{aadInstanceUrl}/{tenantId}");
            string AuthURI = aadInstanceUrl + "/" + tenantId;
            var authenticationContext = new AuthenticationContext(AuthURI);


            var authenticationResult = await authenticationContext.AcquireTokenAsync(organizationUrl, clientcred);
            return authenticationResult.AccessToken;
        }



        public static async Task<string> GetAccessTokenFO()
        {
            string applicationId = "c69e3066-8686-41d6-9e13-84580d072d17";
            string clientSecret = "46?S4N1norBcN.ggdaCqvDjzRLaWiS-@";
            string aadInstanceUrl = "https://login.microsoftonline.com";
            string tenantId = "fdb3d149-830c-485d-a60f-caf3ce704d58";
            string organizationUrl = "https://cfxintdev8ca9f5aa365bdfc9devaos.cloudax.dynamics.com";


            var clientcred = new ClientCredential(applicationId, clientSecret);
            //var authenticationContext = new AuthenticationContext($"{aadInstanceUrl}/{tenantId}");
            string AuthURI = aadInstanceUrl + "/" + tenantId;
            var authenticationContext = new AuthenticationContext(AuthURI);


            var authenticationResult = await authenticationContext.AcquireTokenAsync(organizationUrl, clientcred);
            return authenticationResult.AccessToken;
        }

        public static async Task<ODataClient> GetODataClientFO()
        {
            string token = await GetAccessTokenFO();

            //        "FOApiEndpoint": "https://cfxintdev8ca9f5aa365bdfc9devaos.cloudax.dynamics.com",
            //"FOApiEndpointSuffix": "/data",

            string apiEndPoint = "https://cfxintdev8ca9f5aa365bdfc9devaos.cloudax.dynamics.com";
            apiEndPoint = apiEndPoint + "/data";

            var settings = new ODataClientSettings(new Uri(apiEndPoint));
            settings.BeforeRequest += delegate (HttpRequestMessage message)
            {
                message.Headers.Add("Authorization", "Bearer " + token);
                // message.Headers.Add("Prefer", "odata.include-annotations=\"*\"");
                //  message.Headers.Add("Prefer", "odata.include-annotations=OData.Community.Display.V1.FormattedValue");
            };
            var client = new ODataClient(settings);
            return client;
        }

        //private IODataClient SetOdataSettingsAndReturnFOClient()
        //{
        //    string apiEndpoint = configuration[AppConfigurationKeys.FOApiEndpoint] + configuration[AppConfigurationKeys.FOApiEndpointSuffix];
        //    var settings = new ODataClientSettings(new Uri(apiEndpoint));
        //    settings.BeforeRequest += SetRequestHeadersForFOToken;
        //    var client = new ODataClient(settings);
        //    return client;
        //}



        public static async Task<ODataClient> GetODataClient()
        {
            string token = await GetAccessToken();

            string apiEndPoint = "https://cfxdev.api.crm.dynamics.com/";
            apiEndPoint = apiEndPoint + "api/data/v9.1/";

            var settings = new ODataClientSettings(new Uri(apiEndPoint));
            settings.BeforeRequest += delegate (HttpRequestMessage message)
            {
                message.Headers.Add("Authorization", "Bearer " + token);
                // message.Headers.Add("Prefer", "odata.include-annotations=\"*\"");
                message.Headers.Add("Prefer", "odata.include-annotations=OData.Community.Display.V1.FormattedValue");
            };
            var client = new ODataClient(settings);
            return client;
        }
    }
}
