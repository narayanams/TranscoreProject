using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;
using CFXTranscoreProjects.DataModels;



namespace CallSPFromAzureFunction.StaticClasses
{
    public static class Validate
    {
        public static string ValidateRequest(string RequestJSON)
        {
            try
            {
                RequestRawMessageModel cfxRequest = JsonConvert.DeserializeObject<RequestRawMessageModel>(RequestJSON);
                return StaticClasses.StaticVars.SUCCESS;
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static string ConvertToDateTime(string DateTimeString)
        {
            string ConvertedDateTime = string.Empty;

            try
            {
                DateTime univDateTime = DateTime.Parse(DateTimeString);
                DateTime localDateTime = univDateTime.ToLocalTime();
                DateTime date = DateTime.ParseExact(localDateTime.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                ConvertedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss");
                return ConvertedDateTime;

            }
            catch (Exception e)
            {
                return ConvertedDateTime;
            }


        }
    }

   
}
