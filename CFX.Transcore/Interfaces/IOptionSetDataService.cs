

namespace CallSPFromAzureFunction.Interfaces
{
    using CallSPFromAzureFunction.DAL.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IOptionSetDataService" />
    /// </summary>
    public interface IOptionSetDataService
    {
        /// <summary>
        /// The GetOptionSets
        /// </summary>
        /// <param name="optionSetNames">The optionSetNames<see cref="string[]"/></param>
        /// <returns>The <see cref="Task{Dictionary{string, List{OptionSetResponseModel}}}"/></returns>
        Task<Dictionary<string, List<OptionSetResponseModel>>> GetOptionSets(params string[] optionSetNames);
    }
}
