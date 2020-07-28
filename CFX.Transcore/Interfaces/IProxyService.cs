using System.Threading.Tasks;

namespace CallSPFromAzureFunction.Interfaces
{
    public interface IProxyService
    {
        Task<string> GetDynamicsCEToken();


        Task<string> GetDynamicsFOToken();
    }
}
