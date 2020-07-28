using CallSPFromAzureFunction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CallSPFromAzureFunction.Interfaces
{
    public interface IMasterDataService
    {

        // Task<List<cfx_make>> GetVehicleMakes();


        // Task<List<cfx_model>> GetVehicleModels(string vehicleMake);


        // Task<List<cfx_vehiclecolorcode>> GetVehicleColorCodeOptionLists();


        //  Task<List<cfx_accountstatuscode>> GetAccountStatusCodeLists();


        //Task<List<cfx_platetypes>> GetVehiclePlateTypeLists();


        //Task<List<Accounts>> GetRentalAgencyList(string airportCode, string rentalAgencyName);


        //Task<List<cfx_transpondertypes>> GetTransponderTypesList();


        //Task<Accounts> GetAccountBalance(string accountNumber);


        //  Task<cfx_transponders> GetTransponderAvailablity(string transponderNumber, string accountNumber);


        // Task<bool?> SetReplenishThreshold(string accountNumber, decimal thresoldAmount);


        // Task<cfx_transponders> GetTransponderParkingAllowed(string transponderNumber);
    }
}
