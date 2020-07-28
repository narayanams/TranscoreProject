using System;
using System.Threading.Tasks;

namespace CallSPFromAzureFunction.Interfaces
{
    public interface IExecuteDynamicsServiceCall
    {

        Task<T> ExecuteServiceCall<T>(Func<Task<T>> func, string serviceName = null);
    }
}
