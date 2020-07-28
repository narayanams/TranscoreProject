using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CallSPFromAzureFunction.StaticClasses;
using CallSPFromAzureFunction.Controller;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using CallSPFromAzureFunction.Models;
using System.Globalization;
using CFXTranscoreProjects.DataModels;
using Microsoft.Build.Framework;


namespace CallSPFromAzureFunction.MessageProcess
{
    public static class TranscoreProcess
    {


        public static async Task<ResponseMessage> Process2(RequestRawMessageModel requestRawMessageModel)
        {

            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage.Error = "";

            await DataBaseFunctions.InsertDBRunningLog2("Process2: New RawMessage " + requestRawMessageModel.REQUEST_MESSAGE);

            return responseMessage;

        }
   
        public static async Task<ResponseMessage> Process(RequestRawMessageModel cfxRequest)
        {
            ResponseMessage rm = new ResponseMessage();           
            try
            {
          
                TempController tempController = new TempController();
                string ResponseJSON = string.Empty; ;
             
                CFXAccountResponse cfxAccountResponse;

                switch (cfxRequest.REQUEST_TYPE)
                {

                    //One
                    case StaticRequestType.TagLookupSimple:

                        cfxAccountResponse = await tempController.GetAccountInfoGivenTagNumber(cfxRequest.RequestMesssage.TagNumber, cfxRequest.RequestMesssage.IssuingAuthority);
                     
                        ResponseTypeOneModel responseTypeOneModel = new ResponseTypeOneModel();

                        responseTypeOneModel.RequestType = cfxRequest.REQUEST_TYPE;
                        responseTypeOneModel.RequestId = cfxRequest.CRM_REQUEST_ID;
                        responseTypeOneModel.Requestor = cfxRequest.REQUESTOR;
                        responseTypeOneModel.RequestDate = Validate.ConvertToDateTime(cfxRequest.REQUEST_DATE);
                   
                        if (cfxAccountResponse.Errors.Length == 0)
                        {
                            responseTypeOneModel.ResponseCode = "0";
                            responseTypeOneModel.ResponseMessage = "";
                            responseTypeOneModel.AccountNumber = cfxAccountResponse.AccountNumber;
                            responseTypeOneModel.AccountStatusCurrent = cfxAccountResponse.AccountStatus;
                            responseTypeOneModel.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;
                        }
                        else
                        {
                            responseTypeOneModel.ResponseCode = "1";
                            responseTypeOneModel.ResponseMessage = "Account Not Found for TagNumber:" + cfxRequest.RequestMesssage.TagNumber;
                        }
                        ResponseJSON = JsonConvert.SerializeObject(responseTypeOneModel, Newtonsoft.Json.Formatting.None);

                        rm.JSONMessage = ResponseJSON;

                        break;
                    case StaticRequestType.PlateLookupForVES:

                         cfxAccountResponse = await tempController.GetAccountInfoGivenPlateInfo(cfxRequest.RequestMesssage.LicensePlate, cfxRequest.RequestMesssage.LicenseState);
                     
                        ResponseTypeTwoModel responseTypeTwoModel = new ResponseTypeTwoModel();

                        responseTypeTwoModel.RequestType = cfxRequest.REQUEST_TYPE;
                        responseTypeTwoModel.RequestId = cfxRequest.CRM_REQUEST_ID;
                        responseTypeTwoModel.Requestor = cfxRequest.REQUESTOR;
                        responseTypeTwoModel.RequestDate = cfxRequest.REQUEST_DATE;

                        if (cfxAccountResponse.Errors.Length == 0)
                        {
                            responseTypeTwoModel.ResponseCode = "0";
                            responseTypeTwoModel.ResponseMessage = "";
                            responseTypeTwoModel.AccountNumber = cfxAccountResponse.AccountNumber;
                            responseTypeTwoModel.AccountStatusCurrent = cfxAccountResponse.AccountStatus;
                            responseTypeTwoModel.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;

                            responseTypeTwoModel.cfxEPASS.TagNumber = cfxAccountResponse.TagNumber;
                            responseTypeTwoModel.cfxEPASS.IssuingAuthority = cfxAccountResponse.IssuingAuthorityCode;
                            responseTypeTwoModel.cfxEPASS.AccountNumber = cfxAccountResponse.AccountNumber;
                            responseTypeTwoModel.cfxEPASS.AccountStatusAtTrans = cfxAccountResponse.AccountStatus;
                            responseTypeTwoModel.cfxEPASS.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;
                           // responseTypeTwoModel.cfxEPASS. = cfxAccountResponse.RevNonRevType;

                            responseTypeTwoModel.cfxTRPP.TagNumber = cfxAccountResponse.TagNumber;
                            responseTypeTwoModel.cfxTRPP.IssuingAuthority = cfxAccountResponse.IssuingAuthorityCode;
                            responseTypeTwoModel.cfxTRPP.StateCode = cfxAccountResponse.StateCode;
                            responseTypeTwoModel.cfxTRPP.AccountNumber = cfxAccountResponse.AccountNumber;
                            responseTypeTwoModel.cfxTRPP.AccountStatusCurrent = cfxAccountResponse.AccountStatusAtTransaction;
                            responseTypeTwoModel.cfxTRPP.AccountStatusCurrent = cfxAccountResponse.AccountStatus;

                            responseTypeTwoModel.cfxPOCH.TagNumber = cfxAccountResponse.TagNumber;
                            responseTypeTwoModel.cfxPOCH.IssuingAuthority = cfxAccountResponse.IssuingAuthority;
                            responseTypeTwoModel.cfxPOCH.StateCode = cfxAccountResponse.StateCode;
                            responseTypeTwoModel.cfxPOCH.AccountNumber = cfxAccountResponse.AccountNumber;

                            responseTypeTwoModel.cfxCHP.TagNumber = cfxAccountResponse.TagNumber;
                            responseTypeTwoModel.cfxCHP.IssuingAuthority = cfxAccountResponse.IssuingAuthority;
                            responseTypeTwoModel.cfxCHP.StateCode = cfxAccountResponse.StateCode;
                            responseTypeTwoModel.cfxCHP.AccountNumber = cfxAccountResponse.AccountNumber;
                            responseTypeTwoModel.cfxCHP.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;

                        }
                        else
                        {
                            responseTypeTwoModel.ResponseCode = "2";
                            responseTypeTwoModel.ResponseMessage = "Account Not Found for TagNumber:" + cfxRequest.RequestMesssage.TagNumber;
                        }
                        ResponseJSON = JsonConvert.SerializeObject(responseTypeTwoModel, Newtonsoft.Json.Formatting.None);

                        rm.JSONMessage = ResponseJSON;


                        break;

                    case StaticRequestType.Loop2Tagas:

                        cfxAccountResponse = await tempController.GetAccountInfoGivenTagNumber(cfxRequest.RequestMesssage.TagNumber, cfxRequest.RequestMesssage.IssuingAuthority);
                     
                        ResponseTypeThreeModel requestTypeThreeModel = new ResponseTypeThreeModel();
                        requestTypeThreeModel.RequestType = cfxRequest.REQUEST_TYPE;
                        requestTypeThreeModel.RequestId = cfxRequest.CRM_REQUEST_ID;
                        requestTypeThreeModel.Requestor = cfxRequest.REQUESTOR;
                        requestTypeThreeModel.RequestDate = Validate.ConvertToDateTime(cfxRequest.REQUEST_DATE);

                        if (requestTypeThreeModel.Errors.Length == 0)
                        {
                            requestTypeThreeModel.ResponseCode = "0";
                            requestTypeThreeModel.ResponseMessage = "";
                            requestTypeThreeModel.AccountNumber = cfxAccountResponse.AccountNumber;
                            requestTypeThreeModel.AccountStatusCurrent = cfxAccountResponse.AccountStatus;
                            requestTypeThreeModel.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;
                        }
                        else
                        {
                            requestTypeThreeModel.ResponseCode = "1";
                            requestTypeThreeModel.ResponseMessage = "Account Not Found for TagNumber:" + cfxRequest.RequestMesssage.TagNumber;
                        }
                        ResponseJSON = JsonConvert.SerializeObject(requestTypeThreeModel, Newtonsoft.Json.Formatting.None);

                        rm.JSONMessage = ResponseJSON;




                        break;
                    case StaticRequestType.Loop2Plates:

                        cfxAccountResponse = await tempController.GetAccountInfoGivenTagNumber(cfxRequest.RequestMesssage.TagNumber, cfxRequest.RequestMesssage.IssuingAuthority);
                        ResponseTypeFourModel requestTypeFourModel = new ResponseTypeFourModel();
                        requestTypeFourModel.RequestType = cfxRequest.REQUEST_TYPE;
                        requestTypeFourModel.RequestId = cfxRequest.CRM_REQUEST_ID;
                        requestTypeFourModel.Requestor = cfxRequest.REQUESTOR;
                        requestTypeFourModel.RequestDate = Validate.ConvertToDateTime(cfxRequest.REQUEST_DATE);

                        if (requestTypeFourModel.Errors.Length == 0)
                        {
                            requestTypeFourModel.ResponseCode = "0";
                            requestTypeFourModel.ResponseMessage = "";
                            requestTypeFourModel.AccountNumber = cfxAccountResponse.AccountNumber;
                            requestTypeFourModel.AccountStatusCurrent = cfxAccountResponse.AccountStatus;
                            requestTypeFourModel.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;
                        }
                        else
                        {
                            requestTypeFourModel.ResponseCode = "1";
                            requestTypeFourModel.ResponseMessage = "Account Not Found for TagNumber:" + cfxRequest.RequestMesssage.TagNumber;
                        }
                        ResponseJSON = JsonConvert.SerializeObject(requestTypeFourModel, Newtonsoft.Json.Formatting.None);

                        rm.JSONMessage = ResponseJSON;


                        break;

                    case StaticRequestType.Rebates:

                        cfxAccountResponse = await tempController.GetAccountInfoGivenTagNumber(cfxRequest.RequestMesssage.TagNumber, cfxRequest.RequestMesssage.IssuingAuthority);
                        ResponseTypeFiveModel requestTypeFiveModel = new ResponseTypeFiveModel();
                        requestTypeFiveModel.RequestType = cfxRequest.REQUEST_TYPE;
                        requestTypeFiveModel.RequestId = cfxRequest.CRM_REQUEST_ID;
                        requestTypeFiveModel.Requestor = cfxRequest.REQUESTOR;
                        requestTypeFiveModel.RequestDate = Validate.ConvertToDateTime(cfxRequest.REQUEST_DATE);

                        if (requestTypeFiveModel.Errors.Length == 0)
                        {
                            requestTypeFiveModel.ResponseCode = "0";
                            requestTypeFiveModel.ResponseMessage = "";
                            requestTypeFiveModel.AccountNumber = cfxAccountResponse.AccountNumber;
                            requestTypeFiveModel.AccountStatusCurrent = cfxAccountResponse.AccountStatus;
                            requestTypeFiveModel.AccountStatusAtTrans = cfxAccountResponse.AccountStatusAtTransaction;
                        }
                        else
                        {
                            requestTypeFiveModel.ResponseCode = "1";
                            requestTypeFiveModel.ResponseMessage = "Account Not Found for TagNumber:" + cfxRequest.RequestMesssage.TagNumber;
                        }
                        ResponseJSON = JsonConvert.SerializeObject(requestTypeFiveModel, Newtonsoft.Json.Formatting.None);

                        rm.JSONMessage = ResponseJSON;


                        break;

                    case StaticRequestType.TagStatus:                      
                        break;

                    case StaticRequestType.MTOLLS:                      
                        break;

                    default:

                        break;



                }
            }
            catch(Exception ex)
            {
                rm.Error = ex.Message.ToString();
            }

          

            return rm;
        }

        public static async Task<bool> InsertDB(string InMessage, string CRMData, string OutMessage)
        {

            string databaseConnection = "Server=tcp:sqlsimserver.database.windows.net,1433;Initial Catalog=TPMessages;Persist Security Info=False;User ID=sqlsimserver;Password=Orlando9876!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            MessageLogModel messageLogModel = new MessageLogModel();
            messageLogModel.InMessage = InMessage;
            messageLogModel.Response = CRMData;
            messageLogModel.Request = OutMessage;

            //  string sqlSP = @"INSERT INTO MessageLog (InMessage, CRMData, OutMessage) VALUES(@InMessage, @CRMData, @OutMessage)";
            string sqlSP = "sp_MessageLog_Insert";

            using (IDbConnection dbConnection = new SqlConnection(databaseConnection))
            {
                try
                {
                    dbConnection.Open();

                    int rowsAffected = await dbConnection.ExecuteAsync(sqlSP, messageLogModel, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0)
                    {
                      //  log.LogInformation("Sucess....");

                    }


                }
                catch (Exception ex)
                {
                   // log.LogInformation(ex.Message.ToString());
                }


            }

            return true;
        }
    }
}
