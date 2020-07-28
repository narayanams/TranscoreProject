using System;
using System.Collections.Generic;
using System.Text;



namespace CallSPFromAzureFunction.DAL.Models
{
    public class Accounts
    {

        public string accountnumber { get; set; }

        /// <summary>
        /// Gets or sets the accountid
        /// </summary>
        public Guid accountid { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the yominame
        /// </summary>
        public string yominame { get; set; }

        /// <summary>
        /// Gets or sets the emailaddress1
        /// </summary>
        public string emailaddress1 { get; set; }

        /// <summary>
        /// Gets or sets the telephone1
        /// </summary>
        public string telephone1 { get; set; }

        /// <summary>
        /// Gets or sets the telephone2
        /// </summary>
        public string telephone2 { get; set; }

        /// <summary>
        /// Gets or sets the telephone3
        /// </summary>
        public string telephone3 { get; set; }

        /// <summary>
        /// Gets or sets the address1_addressid
        /// </summary>
        public Guid address1_addressid { get; set; }

        /// <summary>
        /// Gets or sets the address1_name
        /// </summary>
        public string address1_name { get; set; }

        /// <summary>
        /// Gets or sets the address1_stateorprovince
        /// </summary>
        public string address1_stateorprovince { get; set; }

        /// <summary>
        /// Gets or sets the address1_line2
        /// </summary>
        public string address1_line2 { get; set; }

        /// <summary>
        /// Gets or sets the address1_postalcode
        /// </summary>
        public string address1_postalcode { get; set; }

        /// <summary>
        /// Gets or sets the address1_telephone1
        /// </summary>
        public string address1_telephone1 { get; set; }

        /// <summary>
        /// Gets or sets the address1_city
        /// </summary>
        public string address1_city { get; set; }

        /// <summary>
        /// Gets or sets the address1_line1
        /// </summary>
        public string address1_line1 { get; set; }

        /// <summary>
        /// Gets or sets the address1_addresstypecode
        /// </summary>
        public string address1_addresstypecode { get; set; }

        /// <summary>
        /// Gets or sets the address1_line3
        /// </summary>
        public string address1_line3 { get; set; }

        /// <summary>
        /// Gets or sets the address1_country
        /// </summary>
        public string address1_country { get; set; }

        /// <summary>
        /// Gets or sets the address1_county
        /// </summary>
        public string address1_county { get; set; }

        /// <summary>
        /// Gets or sets the contact_customer_accounts
        /// </summary>
        public Contact contact_customer_accounts { get; set; }

        /// <summary>
        /// Gets or sets the cfx_opendate
        /// </summary>
        public DateTime? cfx_opendate { get; set; }

        /// <summary>
        /// Gets or sets the cfx_accounttypecode
        /// </summary>
        public long? cfx_accounttypecode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_airportsserved
        /// </summary>
        public string cfx_airportsserved { get; set; }

        /// <summary>
        /// Gets or sets the accountcategorycode
        /// </summary>
        public string accountcategorycode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_balanceamount
        /// </summary>
        public decimal? cfx_balanceamount { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isreplenishaccount
        /// </summary>
        public bool cfx_isreplenishaccount { get; set; }

        /// <summary>
        /// Gets or sets the cfx_replenishmentamount
        /// </summary>
        public decimal? cfx_replenishmentamount { get; set; }

        /// <summary>
        /// Gets or sets the cfx_lowbalancethresh
        /// </summary>
        public decimal cfx_lowbalancethresh { get; set; }

        /// <summary>
        /// Gets or sets the cfx_account_cfx_paymenttype_Account
        /// </summary>
     //   public List<cfx_paymenttype> cfx_account_cfx_paymenttype_Account { get; set; }

        /// <summary>
        /// Gets or sets the cfx_lowbalanceamount
        /// </summary>
        public decimal? cfx_lowbalanceamount { get; set; }

        /// <summary>
        /// Gets or sets the cfx_minbalancethresh
        /// </summary>
        public decimal? cfx_minbalancethresh { get; set; }

        /// <summary>
        /// Gets or sets the cfx_islowbalance
        /// </summary>
        public bool cfx_islowbalance { get; set; }

        /// <summary>
        /// Gets or sets the cfx_statementpreferencecode
        /// </summary>
        public string cfx_statementpreferencecode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_statementcyclescode
        /// </summary>
        public long? cfx_statementcyclescode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isemailparkingreceipts
        /// </summary>
        public bool cfx_isemailparkingreceipts { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isallowparking
        /// </summary>
        public bool cfx_isallowparking { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isemailnewsletter
        /// </summary>
        public bool cfx_isemailnewsletter { get; set; }

        /// <summary>
        /// Gets or sets the cfx_emailstatuscode
        /// </summary>
        public string cfx_emailstatuscode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_returnedpostmail
        /// </summary>
        public bool cfx_returnedpostmail { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isoutoffunds
        /// </summary>
        public bool cfx_isoutoffunds { get; set; }

        /// <summary>
        /// Gets or sets the cfx_isuspsletterdeliverymethod
        /// </summary>
        public bool cfx_isuspsletterdeliverymethod { get; set; }

        /// <summary>
        /// Gets or sets the cfx_account_cfx_vehicle_Account
        /// </summary>
        public List<cfx_vehicle> cfx_account_cfx_vehicle_Account { get; set; }

        /// <summary>
        /// Gets or sets the cfx_account_cfx_device
        /// </summary>
      //  public List<cfx_device> cfx_account_cfx_device { get; set; }

        /// <summary>
        /// Gets or sets the modifiedon
        /// </summary>
        public DateTime? modifiedon { get; set; }

        /// <summary>
        /// Gets or sets the cfx_nsfachstatus
        /// </summary>
        public string cfx_nsfachstatus { get; set; }

        /// <summary>
        /// Gets or sets the cfx_nsfachstatuscode
        /// </summary>
        public long? cfx_nsfachstatuscode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_nsfcheckstatuscode
        /// </summary>
        public string cfx_nsfcheckstatuscode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_nsfcreditcardstatuscode
        /// </summary>
        public string cfx_nsfcreditcardstatuscode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_nsfpaymentstatuscode
        /// </summary>
        public string cfx_nsfpaymentstatuscode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_account_cfx_transponder_accountid
        /// </summary>
        public List<cfx_transponders> cfx_account_cfx_transponder_accountid { get; set; }

        /// <summary>
        /// Gets or sets the parentaccountid lookup reference
        /// </summary>
        public Accounts parentaccountid { get; set; }

        /// <summary>
        /// Gets or sets the primarycontactid
        /// </summary>
        public Contact primarycontactid { get; set; }

        /// <summary>
        /// Gets or sets the cfx_account_cfx_accountcommunicationpreferences_Account
        /// </summary>
      //  public List<cfx_accountcommunicationpreferenceses> cfx_account_cfx_accountcommunicationpreferences_Account { get; set; }

        /// <summary>
        /// Gets or sets the cfx_suggestedreplenishmentamount
        /// </summary>
        public decimal? cfx_suggestedreplenishmentamount { get; set; }

        /// <summary>
        /// Gets or sets the cfx_username
        /// </summary>
        public string cfx_username { get; set; }

        /// <summary>
        /// Gets or sets the cfx_tin
        /// </summary>
        public string cfx_tin { get; set; }

        /// <summary>
        /// Gets or sets the MD5 Password
        /// </summary>
        public string cfx_accountpassword { get; set; }

        /// <summary>
        /// Gets or sets the 4 digit pin
        /// </summary>
        public string cfx_pin { get; set; }

        /// <summary>
        /// Gets or sets the login Attempts
        /// </summary>
        public int cfx_loginattempts { get; set; }

        /// <summary>
        /// Gets or sets the Pin login Attempts
        /// </summary>
        public int cfx_pin_login_attempts { get; set; }

        /// <summary>
        /// Gets or sets the Password Reset Attempts
        /// </summary>
        public int cfx_password_reset_attempts_web { get; set; }

        /// <summary>
        /// Gets or sets the Password Change Date. This is being called from ResetPassword flow
        /// </summary>
        public DateTime? cfx_password_change_date { get; set; }

        /// <summary>
        /// Gets or sets the Password Lock Date. This happens when Password Failure Attempt reached to threadhold and lock it there
        /// </summary>
        public DateTime? cfx_password_lock_date { get; set; }

        /// <summary>
        /// Gets or sets the Pin Last Accessed
        /// </summary>
        public DateTime? cfx_pinaccessdate { get; set; }

        /// <summary>
        /// Gets or sets the Pin Last Changed
        /// </summary>
        public DateTime? cfx_pinchangedate { get; set; }

        /// <summary>
        /// Gets or sets the password access date
        /// </summary>
        public DateTime? cfx_passwordaccessdate { get; set; }

        /// <summary>
        /// Gets or sets the cfx_stateid
        /// </summary>
        public cfx_state cfx_stateid { get; set; }

        /// <summary>
        /// Gets or sets the cfx_countryid
        /// </summary>
       // public cfx_country cfx_countryid { get; set; }

        /// <summary>
        /// Gets or sets the cfx_businesstypecode
        /// </summary>
        public long? cfx_businesstypecode { get; set; }

        /// <summary>
        /// Sets or gets the cfx_discountamount
        /// </summary>
        public decimal cfx_discountamount { get; set; }

        /// <summary>
        /// Sets or gets the cfx_discountmonth
        /// </summary>
        public long? cfx_discountmonth { get; set; }

        /// <summary>
        /// Sets or gets the cfx_averageweeklycost
        /// </summary>
        public decimal cfx_averageweeklycost { get; set; }

        /// <summary>
        /// Sets or gets the cfx_averageweeklysavings
        /// </summary>
        public decimal cfx_averageweeklysavings { get; set; }


        /// <summary>
        /// Gets or sets the phone country code
        /// </summary>
        public string cfx_phonecountrycode { get; set; }

        /// <summary>
        /// Gets or sets cfx_numberofactivetransponders
        /// </summary>
        public long? cfx_numberofactivetransponders { get; set; }

        /// <summary>
        /// Gets or sets statecode
        /// </summary>
        public int statecode { get; set; }

        /// <summary>
        /// Gets or sets the cfx_AccountRevenueTypeCode
        /// </summary>
        public long? cfx_AccountRevenueTypeCode { get; set; }
    }
}
