using System;
using System.Collections.Generic;
using System.Text;

namespace CallSPFromAzureFunction.DAL.Models
{
    public class Contact
    {
        public Accounts parentcustomerid_account { get; set; }

        public string cfx_driverslicensenumber { get; set; }
        //  public cfx_state cfx_driverslicensestateid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //  public cfx_state cfx_state_contact_driverslicensestateid { get; set; }
        //  public cfx_state _cfx_driverslicensestateid_value { get; set; }
        public string cfx_driverslicensestate { get; set; }
        public Contact contact_customer_accounts { get; set; }
    }
}
