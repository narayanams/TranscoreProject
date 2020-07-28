using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using CFXTranscoreProjects.Models;
using CallSPFromAzureFunction.SQLDB.Models;
using CallSPFromAzureFunction.StaticClasses;

namespace CallSPFromAzureFunction.StaticClasses
{
    public static class DataBaseFunctions
    {

		public static async Task<bool> InsertDBRunningLog(string InMessage, ILogger log)
		{			
			RunningLogDataViewModel runningLogDataViewModel = new RunningLogDataViewModel();
			runningLogDataViewModel.RunningLog = InMessage;
			string sqlSP = "sp_RunningLogData_Insert";

			using (IDbConnection dbConnection = new SqlConnection(StaticVars.DBConnectionString))
			{
				try
				{
					dbConnection.Open();
					int rowsAffected = await dbConnection.ExecuteAsync(sqlSP, runningLogDataViewModel, commandType: CommandType.StoredProcedure);
                    log.LogInformation("Successfully inserted.");
				}
				catch (Exception ex)
				{
                    log.LogInformation("Error: " + ex.Message.ToString());
				}
			}

			return true;
		}

		public static async Task<bool> InsertDBRunningLog2(string InMessage)
		{
			
			RunningLogDataViewModel runningLogDataViewModel = new RunningLogDataViewModel();
			runningLogDataViewModel.RunningLog = InMessage;
			string sqlSP = "sp_RunningLogData_Insert";

			using (IDbConnection dbConnection = new SqlConnection(StaticVars.DBConnectionString))
			{
				try
				{
					dbConnection.Open();
					int rowsAffected = await dbConnection.ExecuteAsync(sqlSP, runningLogDataViewModel, commandType: CommandType.StoredProcedure);					
				}
				catch (Exception ex)
				{					
				}
			}

			return true;
		}

		public static async Task<bool> InsertDB(int RequestID, int RequestType, string InMessage, string CRMData, string OutMessage, string ErrorMessage)
        {
           
            MessageLogModel messageLogModel = new MessageLogModel();
            messageLogModel.RequestID = RequestID;
            messageLogModel.RequestType = RequestType;
            messageLogModel.InMessage = InMessage;
            messageLogModel.Response = CRMData;
            messageLogModel.Request = OutMessage;
            messageLogModel.ErrorMessage = ErrorMessage;


            
            string sqlSP = "sp_MessageLog_Insert";

            using (IDbConnection dbConnection = new SqlConnection(StaticVars.DBConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    int rowsAffected = await dbConnection.ExecuteAsync(sqlSP, messageLogModel, commandType: CommandType.StoredProcedure);                   
                }
                catch (Exception ex)
                {                  
                }
            }

            return true;
        }

        public static async Task<bool> InsertDBSTRIIMMessages(ILogger log, string InMessage)
        {

          //  string databaseConnection = "Server=tcp:sqlsimserver.database.windows.net,1433;Initial Catalog=TPMessages;Persist Security Info=False;User ID=sqlsimserver;Password=Orlando9876!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            STRIIMMessages striimMessagesModel = new STRIIMMessages();
            striimMessagesModel.STRIIMMessage = InMessage;


            //  string sqlSP = @"INSERT INTO MessageLog (InMessage, CRMData, OutMessage) VALUES(@InMessage, @CRMData, @OutMessage)";
            string sqlSP = "sp_STRIIMMessages_Insert";

            using (IDbConnection dbConnection = new SqlConnection(StaticVars.DBConnectionString))
            {
                try
                {
                    dbConnection.Open();

                    int rowsAffected = await dbConnection.ExecuteAsync(sqlSP, striimMessagesModel, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0)
                    {
                        log.LogInformation("Sucess....");

                    }


                }
                catch (Exception ex)
                {
                    log.LogInformation(ex.Message.ToString());
                }


            }

            return true;
        }




        //public static async Task<bool> InsertDB(ILogger log, int RequestID, string InMessage, string CRMData, string OutMessage)
        //{

        //    string databaseConnection = "Server=tcp:sqlsimserver.database.windows.net,1433;Initial Catalog=TPMessages;Persist Security Info=False;User ID=sqlsimserver;Password=Orlando9876!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //    MessageLogModel messageLogModel = new MessageLogModel();
        //    messageLogModel.RequestID = RequestID;
        //    messageLogModel.InMessage = InMessage;
        //    messageLogModel.Response = CRMData;
        //    messageLogModel.Request = OutMessage;


        //    //  string sqlSP = @"INSERT INTO MessageLog (InMessage, CRMData, OutMessage) VALUES(@InMessage, @CRMData, @OutMessage)";
        //    string sqlSP = "sp_MessageLog_Insert";

        //    using (IDbConnection dbConnection = new SqlConnection(databaseConnection))
        //    {
        //        try
        //        {
        //            dbConnection.Open();

        //            int rowsAffected = await dbConnection.ExecuteAsync(sqlSP, messageLogModel, commandType: CommandType.StoredProcedure);

        //            if (rowsAffected > 0)
        //            {
        //                log.LogInformation("Sucess....");

        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            log.LogInformation(ex.Message.ToString());
        //        }


        //    }

        //    return true;
        //}
    }
}
