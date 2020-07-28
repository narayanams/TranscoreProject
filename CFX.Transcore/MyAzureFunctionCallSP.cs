/////////////////////////////////////////////////////////////////////////////
/////Endpoint=sb://cfxdevdaievh.servicebus.windows.net/;SharedAccessKeyName=SendAndReceive;SharedAccessKey=8gtQuahDwPUPvwRWT+TvCbosHm74nZDkEbmDqGZOsFA=;EntityPath=tp-intake
///This azure function fire on an azure event hub above.
///This is as per Transcore message types, each input message is process based on the message type.
///Response  is sent to RabbitMQ server.
///Details of each processed log is written to  TPMessage in SQLSIMSERVER IN azure SQL///////////////////
//////////////////////////////////////////////////////////////////////////////
///Messages are sent to Event hub via striim message, the source of data is Oracle 
///Upon getting to event hub message is processed
///Logging: TPMessageLog
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace CallSPFromAzureFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using CallSPFromAzureFunction.Models;
    using Newtonsoft.Json;
    using CallSPFromAzureFunction.MessageProcess;
    using CallSPFromAzureFunction.Transcore;
    using CallSPFromAzureFunction.StaticClasses;
    using CFXTranscoreProjects.DataModels;



    public static class MyAzureFunctionCallSP
    {
        [FunctionName("MyAzureFunctionCallSP")]
        public static async Task Run([EventHubTrigger("MyAzureFunctionCallSP", Connection = "AzureEventHubConnectionString")] EventData[] events, ILogger log)
        {
            var exceptions = new List<Exception>();
         			               
            /////////////////////Loop thru messages as is//////////////////////////////////////////////////
            foreach (EventData eventData in events)
            {
               
                var MainMessage = string.Empty;
						
				try
                {

                    string ErrorsInObject = string.Empty;

                    //Get the message from event hub/////////////////////////////
                    string messageBody = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                    MainMessage = messageBody;

                    /////Temp Logging log to DB as is:
                    await DataBaseFunctions.InsertDBSTRIIMMessages(log, messageBody);
                                      
                    //JSON message object collection schema
                    List<RootObject> rootObjectCollection = new List<RootObject>();
                    
                    // Deserilize to object collection.
                    rootObjectCollection = ConvertMessageToObject(messageBody, ref ErrorsInObject);
                                    
                    if (rootObjectCollection != null)
                    {                       
                        foreach (RootObject rootObject in rootObjectCollection)
                        {

                            // Start the logging collection for every loop as the the logging happens in TPMessageLog
                            ErrorResponseMessages errorResponseMessage = new ErrorResponseMessages();
                            
                            // serilize the object
                            string JsonString = JsonConvert.SerializeObject(rootObject.data, Formatting.None);

                            ////////////////////////////Alter input message: This is from ProcessTest Test data ////////////////////////////
                            ///////////////THere is a reason to do this, this is helps in proper logging.
                            ///For now this is hardcoded for a specific tagnumber. For message type 1
                            RequestRawMessageModel requestRawMessageModel = JsonConvert.DeserializeObject<RequestRawMessageModel>(JsonString);
                            RequestMessageModel requestMessageModel = JsonConvert.DeserializeObject<RequestMessageModel>(requestRawMessageModel.REQUEST_MESSAGE);
                            requestMessageModel.TagNumber = "015015018";
                            requestRawMessageModel.RequestMesssage = requestMessageModel;
                            string ConvertMessage = JsonConvert.SerializeObject(requestRawMessageModel, Formatting.None);
                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            // This does not mean there is error, error object is same as logging.                               
                            errorResponseMessage.RequestMessage = JsonString;

                            if (ConvertMessage.Length > 0)
                            {
                                // Validate the message
                                string ValidateMessage = StaticClasses.Validate.ValidateRequest(ConvertMessage);

                                if (ValidateMessage == StaticClasses.StaticVars.SUCCESS)
                                {
                                    errorResponseMessage.MessageValidation = "True";

                                    //ALL MAIN PROCESS HAPPENS HERE///////////////////////////////////////////////////////////
                                    ResponseMessage ResponseJSON = await TranscoreProcess.Process(requestRawMessageModel);///
                                    ////////////////////////////////////////////////////////////////////////////////////////

                                    errorResponseMessage.ResponseMessage = ResponseJSON.JSONMessage;

                                    if (ResponseJSON.Error.Length > 0)
                                    {
                                        errorResponseMessage.MessageProcessStatus = false;
                                        errorResponseMessage.ErrorResponseMessage = errorResponseMessage.ErrorResponseMessage + " | " + ResponseJSON.Error;
                                    }
                                    else
                                    {
                                        //SEND TO RABBITMQ
                                        SendToQueue(ResponseJSON.JSONMessage, errorResponseMessage);
                                    }                                                                                                                                           
                                }
                                else
                                {
                                    errorResponseMessage.MessageValidation = "False";
                                    log.LogInformation($"Invalid Message");
                                }
                            }
                            else
                            {
                                log.LogInformation($"Message Length is ZERO: {ConvertMessage}");
                            }

                            string jsonMessageError = JsonConvert.SerializeObject(errorResponseMessage, Formatting.None);

                            await DataBaseFunctions.InsertDB(requestRawMessageModel.CRM_REQUEST_ID, requestRawMessageModel.REQUEST_TYPE, jsonMessageError, errorResponseMessage.ResponseMessage, errorResponseMessage.RequestMessage, errorResponseMessage.ErrorResponseMessage);
                       
                        }
                                           
                       // await InsertDB(log,0,jsonMessageError, "Success", "OutMessage");                     
                        log.LogInformation($"C# Event Hub trigger function processed a message: {messageBody}");
                        await Task.Yield();
                    }
                    else
                    {
                        

                     
                    }
                }
                catch (Exception e)
                {

                    await DataBaseFunctions.InsertDB(9999,0, MainMessage, "", "", "Invalid Message");
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }


        private static async void SendToQueue(string MessageToRabbitMQ, ErrorResponseMessages errorResponseMessage)
        {
          
            try
            {
                RabbitProducer producer = new RabbitProducer();
                producer.Connect();             
                string ResponseFromQ = producer.SendSimpleMessage(MessageToRabbitMQ, 1);   
                
                if(ResponseFromQ.Length > 0)
                    errorResponseMessage.SentToRabbitMQ = "Error while sending to Queue : " + ResponseFromQ;
                else
                    errorResponseMessage.SentToRabbitMQ = "Success";


                producer.Disconnect();
               
            }
            catch (Exception ex)
            {
                errorResponseMessage.MessageProcessStatus = false;
                errorResponseMessage.SentToRabbitMQ = "Error: " + ex.Message.ToString();
                errorResponseMessage.ErrorResponseMessage = errorResponseMessage.ErrorResponseMessage + " | At Connection RabbitMQ: " + ex.Message.ToString() + " | " ;
            }          
        }

        private static List<RootObject> ConvertMessageToObject(string Message, ref string Errors)
        {
            var rootObject = new List<RootObject>();            
            try
            {
                rootObject = JsonConvert.DeserializeObject<List<RootObject>>(Message);
               
            }
            catch(Exception ex)
            {
                Errors = ex.Message.ToString();
            }
            return rootObject;
        }

     
    }
}
