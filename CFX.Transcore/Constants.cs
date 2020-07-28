using System.Diagnostics.CodeAnalysis;

namespace CallSPFromAzureFunction
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {

        public const string GlobalOptionSetDefination = "GlobalOptionSetDefinitions(Name='{0}')";


        public const string VehicleColorCodeOptionSet = "cfx_vehiclecolorcode";


        public const string AccountTypeCodeOptionSet = "cfx_accounttypecode";


        public const string LicensePlateTypeCodeOptionSet = "cfx_licenseplatetypecode";


        public const string AirportOptionSet = "cfx_airport";


        public const string OptionSetValue = "Value";


        public const string Options = "Options";


        public const string Label = "Label";


        public const string LocalizedLabel = "LocalizedLabels";


        public const string Description = "Description";


        public const decimal DecimalDefualtValue = 0.00M;


        public const string AccountStatusCodeOptionSet = "cfx_accountstatuscode";


        public const string CreditCardTypeOptionSet = "cfx_creditcardtype";


        public const string ExpirationMonthOptionSet = "cfx_expirationmonth";


        public const string ExpirationYearOptionSet = "cfx_expirationyear";


        public const string ValidDateTimeFormat1 = "MM-dd-yyyy";


        public const string ValidDateTimeFormat2 = "MM/dd/yyyy";

        public const string StatementPreferenceOptionSet = "cfx_statementpreference";


        public const string StatementPreferenceNoStatement = "No Statement";


        public const string StatementPreferenceEmailLink = "Email Statement w/ Link";


        public const string StatementPreferenceEmailAttachment = "Email Statement w/ Attachment";


        public const string StatementPreferenceMailStatement = "Mail Statement";


        public const string AllOptionSets = "AllOptionSets";


        public const string RefreshingMemoryCache = "Refreshing in-memory cache";


        public const string DynamicsFODataEndpointSuffix = "/data";


        public const string DynamicsCEDataEndpointSuffix = "api/data/v9.1/";

        public const string API_CALL_STARTED = "API call started";
    }
}
