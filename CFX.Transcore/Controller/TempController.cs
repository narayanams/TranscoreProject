using System;
using System.Collections.Generic;
using System.Text;
using Simple.OData.Client;
using CallSPFromAzureFunction.DataService;
using CallSPFromAzureFunction.Interfaces;
using CallSPFromAzureFunction.Secrets.Interfaces;
using CallSPFromAzureFunction.Secrets;
using CallSPFromAzureFunction.CommonService;
using CallSPFromAzureFunction.Models;
using CallSPFromAzureFunction.DAL.Models;
using System.Threading.Tasks;
using CFXTranscoreProjects.DataModels;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using CallSPFromAzureFunction.StaticClasses;


namespace CallSPFromAzureFunction.Controller
{
    public class TempController
    {

        public async Task<CFXAccountResponse> GetAccountInfoGivenTagNumber(string TagNumber, string AgencyCode)
        {

            CFXAccountResponse cfxAR = new CFXAccountResponse();
            try
            {                           
                    ODataClient _client = await ConnectionClass.GetODataClient();
                   // string TagNumber = "015015018";
                    var data = await _client.For<cfx_transponders>().Expand(x => x.cfx_accountid).Expand(y => y.cfx_agencyid).Filter(x => x.cfx_name == TagNumber).FindEntryAsync();
                    string AccountNumber = data.cfx_accountid.accountnumber; ;
                 //   await InsertDB(log, 989898, "AccountNumber: " + AccountNumber, "CRMData", "OutMessage");
              
             //   await InsertDB("TagNumber: " + TagNumber, "", "");
                // var data = await client.For<cfx_transponders>().Expand(x => x.cfx_accountid).Expand(y => y.cfx_agencyid).Filter(x => x.cfx_name == TagNumber).Filter(y => y.cfx_agencyid.cfx_agencycode == AgencyCode).FindEntryAsync();
              //  var data = await client.For<cfx_transponders>().Expand(x => x.cfx_accountid).Expand(y => y.cfx_agencyid).Filter(x => x.cfx_name == TagNumber.Trim()).FindEntryAsync();

                // Request Type - 1

                if (data != null)
                {

                   // await InsertDB("Data Not Null: AccountNumber: " + data.cfx_accountid.accountnumber, "", "");

                    cfxAR.AccountNumber = data.cfx_accountid.accountnumber; ;
                    cfxAR.AccountStatus = "A";
                    cfxAR.AccountStatusAtTransaction = "A";
                }
                else
                {
                  //  await InsertDB("Data Null: AccountNumber: " + data.cfx_accountid.accountnumber, "", "");
                }
               

                //A - Active C- Closed I - INsufficient and not in reclaimed revenue
                // L - Low Balance
                // R - INsufficient, but in reclaimed Revenue



                //cfxAR.AccountStatus = data.cfx_accountid.s;

                //  string TagNumber = transponderNumber;
                string IssuingAuthority = data.cfx_agencyid.cfx_name;
                string StateCode = "05";// need to get answer from Maral

            }
            catch(Exception ex)
            {
               // await InsertDB("Data Error: " + ex.Message.ToString(), "", "");
                cfxAR.Errors = ex.Message.ToString();
            }


          //  var results = await client.For<Accounts>().Filter(c => c.accountnumber == AccountNumber).FindEntryAsync();

            return cfxAR;
        }

        public async Task<CFXAccountResponse> GetAccountInfoGivenPlateInfo(string LicensePlate, string LicenseState)
        {

            CFXAccountResponse cfxAR = new CFXAccountResponse();
            try
            {
                ODataClient _client = await ConnectionClass.GetODataClient();

                //var data = await _client.For<cfx_vehicle>().Expand(x => x.cfx_accountid)
                //                                         .Expand(x => x.cfx_transponderid)
                //                                         .Expand(x => x.cfx_licenseplatestateid)
                //                                         .Filter(x => x.cfx_name == LicensePlate && x.cfx_licenseplatestateid.cfx_name == "Florida").FindEntryAsync();

               
                var data = await _client.For<cfx_vehicle>().Expand(x => x.cfx_accountid)
                                                                .Expand(x => x.cfx_transponderid)
                                                                .Expand(x => x.cfx_licenseplatestateid)
                                                                .Filter(x => x.cfx_name == LicensePlate && x.cfx_licenseplatestateid.cfx_name == "Florida").FindEntryAsync();

                string AccountNumber = data.cfx_accountid.accountnumber;
                string TagNumber = data.cfx_transponderid.cfx_name;
                int Status = data.cfx_transponderid.statecode.Value;
                long RevNonRevType = data.cfx_transponderid.cfx_accountid.cfx_AccountRevenueTypeCode.Value;
                string TransponderName = data.cfx_transponderid.cfx_name;
                Guid TransactionGuid = data.cfx_transponderid.cfx_transponderid;
                

               // cfx_accountrevenuetypecode

                var Transaction = await _client.For<cfx_transponders>().Expand(x => x.cfx_agencyid).Filter(x => x.cfx_transponderid == TransactionGuid).FindEntryAsync();

                string IssuingAuthority = Transaction.cfx_agencyid.cfx_name;
                string IssuingAuthorityCode = Transaction.cfx_agencyid.cfx_agencycode;





               // string AccountNumber = data.cfx_accountid.accountnumber; ;
                

                if (data != null)
                {
                 
                    cfxAR.AccountNumber = data.cfx_accountid.accountnumber; ;
                    cfxAR.AccountStatus = "A";
                    cfxAR.AccountStatusAtTransaction = "A";
                    cfxAR.TagNumber = TagNumber;
                    cfxAR.StateCode = Status.ToString();
                    cfxAR.RevNonRevType = RevNonRevType.ToString();
                    cfxAR.IssuingAuthority = IssuingAuthority;
                    cfxAR.IssuingAuthorityCode = IssuingAuthorityCode;
                    
                }
                else
                {
                    
                }

                
                //A - Active C- Closed I - INsufficient and not in reclaimed revenue
                // L - Low Balance
                // R - INsufficient, but in reclaimed Revenue



                //cfxAR.AccountStatus = data.cfx_accountid.s;

                //  string TagNumber = transponderNumber;
               // string IssuingAuthority = data.cfx_agencyid.cfx_name;
              //  string StateCode = "05";// need to get answer from Maral

            }
            catch (Exception ex)
            {
                // await InsertDB("Data Error: " + ex.Message.ToString(), "", "");
                cfxAR.Errors = ex.Message.ToString();
            }


            //  var results = await client.For<Accounts>().Filter(c => c.accountnumber == AccountNumber).FindEntryAsync();

            return cfxAR;

           
        }


      
    }
}
