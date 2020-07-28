using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.Secrets.Interfaces
{
    public interface IKeyvaultProvider
    {
        string GetSecretKeyAsync(string key);
        Dictionary<string, string> GetAllSecrets();
    }
}
