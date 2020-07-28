using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using CallSPFromAzureFunction.Secrets.Interfaces;

namespace CallSPFromAzureFunction.Secrets
{
    public class KeyvaultProvider : IKeyvaultProvider
    {
        private KeyVaultClient keyVaultClient = null;


        private IConfiguration configuration { get; }


        private readonly string _vaultBaseUrl;

        public KeyvaultProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            this._vaultBaseUrl = this.configuration[AppSettingKeys.KV_VaultBaseURL];
        }

        public KeyvaultProvider(string VaultBaseURL)
        {
            //  this.configuration = configuration;
            //  this._vaultBaseUrl = this.configuration[AppSettingKeys.KV_VaultBaseURL];
            this._vaultBaseUrl = VaultBaseURL;
        }


        public string GetSecretKeyAsync(string key)
        {
            keyVaultClient = GetKeyVaultClient();
            var secret = keyVaultClient.GetSecretAsync(_vaultBaseUrl, key).GetAwaiter().GetResult();
            return secret.Value;
        }


        private KeyVaultClient GetKeyVaultClient()
        {
            if (keyVaultClient is null)
            {
                var tokenProvider = new AzureServiceTokenProvider();
                keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));
            }

            return keyVaultClient;
        }


        [Obsolete("GetAllSecrets method is deprecated, using GetSecretKeyAsync method for each secret key")]
        public Dictionary<string, string> GetAllSecrets()
        {
            Dictionary<string, string> secretList = new Dictionary<string, string>();

            keyVaultClient = GetKeyVaultClient();
            var allSecrets = keyVaultClient.GetSecretsAsync(_vaultBaseUrl);
            string seperator = "secrets/";
            foreach (SecretItem secretItem in allSecrets.Result)
            {
                if (!Convert.ToBoolean(secretItem.Managed))
                {
                    var secretnameStr = Convert.ToString(secretItem.Identifier);
                    var secretBundle = keyVaultClient.GetSecretAsync(secretnameStr);
                    secretBundle.Wait();
                    var secretNameIndex = secretnameStr.IndexOf(seperator) + seperator.Length;
                    string secretName = secretnameStr.Substring(secretNameIndex);
                    secretList.Add(secretName, secretBundle.Result.Value);
                }
            }
            return secretList;
        }
    }
}
