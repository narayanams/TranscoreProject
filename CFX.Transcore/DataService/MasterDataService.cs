using CallSPFromAzureFunction.DAL.Models;
using CallSPFromAzureFunction.Interfaces;
using CallSPFromAzureFunction.Models;
using Microsoft.Extensions.Logging;
using Simple.OData.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CallSPFromAzureFunction.DataService
{
    public class MasterDataService : IMasterDataService
    {
        /// <summary>
        /// Defines the client
        /// </summary>
        protected readonly IODataClient client;

        /// <summary>
        /// Defines the executeDynamicsServiceCall
        /// </summary>
        private readonly IExecuteDynamicsServiceCall executeDynamicsServiceCall;

        /// <summary>
        /// Defines the logger
        /// </summary>
        private readonly ILogger<MasterDataService> logger;

        /// <summary>
        /// Defines the optionSetDataService
        /// </summary>
        private readonly IOptionSetDataService optionSetDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDataService"/> class.
        /// </summary>
        /// <param name="odataService">The odataService<see cref="IOdataService"/></param>
        /// <param name="executeDynamicsServiceCall">The executeDynamicsServiceCall<see cref="IExecuteDynamicsServiceCall"/></param>
        /// <param name="logger">The logger<see cref="ILogger{MasterDataService}"/></param>
        /// <param name="optionSetDataService">The optionSetDataService<see cref="IOptionSetDataService"/></param>
        public MasterDataService(IOdataService odataService, IExecuteDynamicsServiceCall executeDynamicsServiceCall, ILogger<MasterDataService> logger, IOptionSetDataService optionSetDataService)
        {
            this.client = odataService.GetDynamicsCEClient();
            this.executeDynamicsServiceCall = executeDynamicsServiceCall;
            this.logger = logger;
            this.optionSetDataService = optionSetDataService;
        }

        /// <summary>
        /// The GetVehicleMakes
        /// </summary>
        /// <returns>The <see cref="Task{List{cfx_make}}"/></returns>
        //async Task<List<cfx_make>> IMasterDataService.GetVehicleMakes()
        //{
        //    var vehicleMakes = await this.executeDynamicsServiceCall.ExecuteServiceCall(() => this.client.For<cfx_make>().FindEntriesAsync(), nameof(IMasterDataService.GetVehicleMakes));
        //    if (vehicleMakes != null && vehicleMakes.Any())
        //    {
        //        return vehicleMakes.ToList();
        //    }
        //    return null;
        //}

        /// <summary>
        /// The GetVehicleModels
        /// </summary>
        /// <param name="vehicleMake">The vehicleMake<see cref="string"/></param>
        /// <returns>The <see cref="Task{List{cfx_model}}"/></returns>
        //async Task<List<cfx_model>> IMasterDataService.GetVehicleModels(string vehicleMake)
        //{
        //    var requiredVehicleMake = await this.executeDynamicsServiceCall.ExecuteServiceCall(() => client.For<cfx_make>().Filter(x => x.cfx_name == vehicleMake).Expand(x => x.cfx_make_cfx_model_makeid).FindEntriesAsync(), nameof(IMasterDataService.GetVehicleModels));
        //    if (requiredVehicleMake != null && requiredVehicleMake.Any() && requiredVehicleMake.FirstOrDefault().cfx_make_cfx_model_makeid.Any())
        //    {
        //        return requiredVehicleMake.FirstOrDefault().cfx_make_cfx_model_makeid;
        //    }
        //    return null;
        //}

        /// <summary>
        /// The GetAccountBalance
        /// </summary>
        /// <param name="accountNumber">The Account Number<see cref="string"/></param>
        /// <returns>The <see cref="Task{Accounts}"/></returns>
        public async Task<Accounts> GetAccountBalance(string accountNumber)
        {
            var accountBalanceResult = await this.executeDynamicsServiceCall.ExecuteServiceCall(() =>
            client.For<Accounts>().Filter(c => c.accountnumber == accountNumber).Select(x => x.cfx_balanceamount).FindEntryAsync(), nameof(GetAccountBalance));
            return accountBalanceResult;
        }

        /// <summary>
        /// The GetVehicleColorCodeOptionLists
        /// </summary>
        /// <returns>The <see cref="Task{List{cfx_vehiclecolorcode}}"/></returns>
        //async Task<List<cfx_vehiclecolorcode>> IMasterDataService.GetVehicleColorCodeOptionLists()
        //{
        //    var vehicleColorOptionSet = new List<cfx_vehiclecolorcode>();
        //    var optionSet = await this.optionSetDataService.GetOptionSets(Constants.VehicleColorCodeOptionSet);
        //    if (optionSet != null && optionSet.Any())
        //    {
        //        foreach (var option in optionSet[Constants.VehicleColorCodeOptionSet])
        //        {
        //            vehicleColorOptionSet.Add(new cfx_vehiclecolorcode
        //            {
        //                ColorName = option.Label,
        //                ColorCode = option.Value
        //            });
        //        }
        //    }

        //    return vehicleColorOptionSet;
        //}

        /// <summary>
        /// The GetAccountStatusCodeLists
        /// </summary>
        /// <returns>The <see cref="Task{List{cfx_accountstatuscode}}"/></returns>
        //async Task<List<cfx_accountstatuscode>> IMasterDataService.GetAccountStatusCodeLists()
        //{
        //    var accountTypes = new List<cfx_accountstatuscode>();
        //    var optionSet = await this.optionSetDataService.GetOptionSets(Constants.AccountStatusCodeOptionSet);

        //    if (optionSet != null && optionSet.Any())
        //    {
        //        foreach (var option in optionSet[Constants.AccountStatusCodeOptionSet])
        //        {
        //            accountTypes.Add(new cfx_accountstatuscode
        //            {
        //                Id = option.Value,
        //                Value = option.Label
        //            });
        //        }
        //    }

        //    return accountTypes;
        //}

        /// <summary>
        /// The GetVehiclePlateTypeLists
        /// </summary>
        /// <returns>The <see cref="Task{List{cfx_platetypes}}"/></returns>
        //async Task<List<cfx_platetypes>> IMasterDataService.GetVehiclePlateTypeLists()
        //{
        //    var plateTypes = new List<cfx_platetypes>();
        //    var optionSet = await this.optionSetDataService.GetOptionSets(Constants.LicensePlateTypeCodeOptionSet);

        //    if (optionSet != null && optionSet.Any())
        //    {
        //        foreach (var option in optionSet[Constants.LicensePlateTypeCodeOptionSet])
        //        {
        //            plateTypes.Add(new cfx_platetypes
        //            {
        //                Code = option.Value,
        //                Description = option.Label
        //            });
        //        }
        //    }

        //    return plateTypes;
        //}

        /// <summary>
        /// The GetRentalAgencyList
        /// </summary>
        /// <param name="airportCode">The airportCode<see cref="string"/></param>
        /// <param name="rentalAgencyName">The rentalAgencyName<see cref="string"/></param>
        /// <returns>The <see cref="Task{List{Accounts}}"/></returns>
        //async Task<List<Accounts>> IMasterDataService.GetRentalAgencyList(string airportCode, string rentalAgencyName)
        //{
        //    var optionSet = await this.optionSetDataService.GetOptionSets(Constants.AccountTypeCodeOptionSet, Constants.AirportOptionSet);
        //    long rentalAgencyId = 0;
        //    string airportOptionSetCode = string.Empty;

        //    if (optionSet != null && optionSet.Any())
        //    {
        //        foreach (var option in optionSet[Constants.AccountTypeCodeOptionSet])
        //        {
        //            if (option.Label.Equals(rentalAgencyName, System.StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                rentalAgencyId = long.Parse(option.Value.ToString());
        //                break;
        //            }
        //        }

        //        foreach (var option in optionSet[Constants.AirportOptionSet])
        //        {
        //            if (option.Label.Equals(airportCode, System.StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                airportOptionSetCode = option.Value;
        //                break;
        //            }
        //        }
        //    }

        //    var requiredAccounts = await this.executeDynamicsServiceCall.ExecuteServiceCall(() => client.For<Accounts>().Filter(x => x.cfx_accounttypecode == rentalAgencyId).FindEntriesAsync(), nameof(IMasterDataService.GetRentalAgencyList));
        //    if (requiredAccounts != null && requiredAccounts.Any() && !string.IsNullOrWhiteSpace(airportOptionSetCode))
        //    {
        //        var filteredAccounts = requiredAccounts.Where(x => !string.IsNullOrWhiteSpace(x.cfx_airportsserved) && x.cfx_airportsserved.Contains(airportOptionSetCode))?.ToList();
        //        return filteredAccounts;
        //    }
        //    return null;
        //}

        /// <summary>
        /// The GetTransponderTypesList
        /// </summary>
        /// <returns>The <see cref="Task{List{cfx_transpondertypes}}"/></returns>
        //async Task<List<cfx_transpondertypes>> IMasterDataService.GetTransponderTypesList()
        //{
        //    var transponderTypes = await this.executeDynamicsServiceCall.ExecuteServiceCall(() => this.client.For<cfx_transpondertypes>().FindEntriesAsync(), nameof(IMasterDataService.GetTransponderTypesList));
        //    if (transponderTypes != null && transponderTypes.Any())
        //    {
        //        return transponderTypes.ToList();
        //    }
        //    return null;
        //}

        /// <summary>
        /// The GetTransponderAvailablity
        /// </summary>
        /// <param name="transponderNumber">The transponderNumber<see cref="string"/></param>
        /// <param name="accountNumber">The accountNumber<see cref="string"/></param>
        /// <returns>The <see cref="Task{cfx_transponders}"/></returns>
        //async Task<cfx_transponders> IMasterDataService.GetTransponderAvailablity(string transponderNumber, string accountNumber)
        //{
        //    return await this.executeDynamicsServiceCall.ExecuteServiceCall(
        //        () => this.client.For<cfx_transponders>()
        //        .Expand(x => x.cfx_accountid)
        //        .Filter(x => x.cfx_name == transponderNumber && x.cfx_accountid.accountnumber == accountNumber)
        //        .FindEntryAsync(),
        //        nameof(IMasterDataService.GetTransponderAvailablity)
        //        );
        //}

        /// <summary>
        /// The GetTransponderParkingAllowed
        /// </summary>
        /// <param name="transponderNumber"></param>
        /// <returns></returns>
        //public async Task<cfx_transponders> GetTransponderParkingAllowed(string transponderNumber)
        //{
        //    return await this.executeDynamicsServiceCall.ExecuteServiceCall(
        //        () => this.client.For<cfx_transponders>()
        //        .Expand(x => x.cfx_accountid)
        //        .Filter(x => x.cfx_name == transponderNumber)
        //        .FindEntryAsync(),
        //        nameof(IMasterDataService.GetTransponderParkingAllowed)
        //        );
        //}

        /// <summary>
        /// The SetReplenishThreshold
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="thresoldAmount"></param>
        /// <returns>The <see cref="Task{bool?}/>"</returns>
        //public async Task<bool?> SetReplenishThreshold(string accountNumber, decimal thresoldAmount)
        //{
        //    var account = await this.executeDynamicsServiceCall.ExecuteServiceCall(() => this.client.For<Accounts>().Filter(p => p.accountnumber == accountNumber).FindEntryAsync(), nameof(IMasterDataService.SetReplenishThreshold));
        //    if (account != null)
        //    {
        //        await this.executeDynamicsServiceCall.ExecuteServiceCall(() => this.client.For<Accounts>().Filter(p => p.accountnumber == accountNumber).Set(new { cfx_lowbalancethresh = thresoldAmount }).UpdateEntryAsync(true), nameof(IMasterDataService.SetReplenishThreshold));
        //        return true;
        //    }
        //    return null;
        //}

    }
}
