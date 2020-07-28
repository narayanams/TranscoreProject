using CallSPFromAzureFunction.Interfaces;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;
using CallSPFromAzureFunction.Secrets.Interfaces;

namespace CallSPFromAzureFunction.CommonService
{
    public class ProxyService : IProxyService
    {
        protected readonly AzureServiceTokenProvider tokenProvider;

        /// <summary>
        /// Defines the keyVaultClient
        /// </summary>
        protected readonly KeyVaultClient keyVaultClient;

        /// <summary>
        /// Defines the keyvaultProvider
        /// </summary>
        protected readonly IKeyvaultProvider keyvaultProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyService"/> class.
        /// </summary>
        /// <param name="keyvaultProvider">The keyvaultProvider<see cref="IKeyvaultProvider"/></param>
        public ProxyService(IKeyvaultProvider keyvaultProvider)
        {
            tokenProvider = new AzureServiceTokenProvider();
            keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));
            this.keyvaultProvider = keyvaultProvider;
        }

        /// <summary>
        /// The GetToken
        /// </summary>
        /// <returns>The <see cref="Task{string}"/></returns>
        public async Task<string> GetDynamicsCEToken()
        {
            // var clientid = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsClientId);
            //  var clientSecret = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsClientSecret);
            //  var tenantId = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsTenantId);
            //   string apiEndpoint = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsApiEndpoint);

            string clientid = "fa9f4554-c699-40c6-b81a-2a06356f7cd8";
            string clientSecret = "M*0eS]lC:2nE.ffNhHwIA3S7@fQYbXZ-";
            string aadInstanceUrl = "https://login.microsoftonline.com";
            string tenantId = "fdb3d149-830c-485d-a60f-caf3ce704d58";
            string organizationUrl = "https://cfxdev.api.crm.dynamics.com/";

            string apiEndpoint = "https://cfxdev.api.crm.dynamics.com/";
            apiEndpoint = apiEndpoint + "api/data/v9.1/";

            return await GetTokenFromCredentials(clientid, clientSecret, tenantId, apiEndpoint);
        }

        /// <summary>
        /// The GetDynamicsFOToken
        /// </summary>
        /// <returns>The <see cref="Task{string}"/></returns>
        public async Task<string> GetDynamicsFOToken()
        {
            var clientid = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsFOClientId);
            var clientSecret = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsFOClientSecret);
            var tenantId = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsFOTenantId);
            string apiEndpoint = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsFOApiEndpoint);
            return await GetTokenFromCredentials(clientid, clientSecret, tenantId, apiEndpoint);
        }

        /// <summary>
        /// The GetTokenFromCredentials
        /// </summary>
        /// <param name="clientid">The clientid<see cref="string"/></param>
        /// <param name="clientSecret">The clientSecret<see cref="string"/></param>
        /// <param name="tenantId">The tenantId<see cref="string"/></param>
        /// <param name="apiEndpoint">The apiEndpoint<see cref="string"/></param>
        /// <returns>The <see cref="Task{string}"/></returns>
        private async Task<string> GetTokenFromCredentials(string clientid, string clientSecret, string tenantId, string apiEndpoint)
        {
            var creds = new ClientCredential(clientid, clientSecret);
            string aadInstance = this.keyvaultProvider.GetSecretKeyAsync(KeyVaultKeys.DynamicsAADInstance);
            AuthenticationContext context = new AuthenticationContext(aadInstance + tenantId);
            var token = await context.AcquireTokenAsync(apiEndpoint, creds);
            if (token != null)
            {
                return token.AccessToken;
            }
            return String.Empty;
        }
    }
}
