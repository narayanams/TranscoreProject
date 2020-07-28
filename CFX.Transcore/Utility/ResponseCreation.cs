using CallSPFromAzureFunction.Models;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallSPFromAzureFunction.Utility
{
    public static class ResponseCreation
    {

        public static ResponseModel<T> CreateResponseModel<T>(T result, List<string> errorMessages, bool isSuccessful = false) where T : new()
        {
            var res = new ResponseModel<T>
            {
                Successful = isSuccessful,
                Errors = errorMessages ?? new List<string>(),
                Results = Equals(result, default(T)) ? new T() : result
            };

            return res;
        }
    }
}
