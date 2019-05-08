using System;

namespace BuckarooSdk.Services.Transfer.TransactionRequest
{
    public class TransferPayRequest
    {
		/// <summary>
		/// The first name of the customer.
		/// </summary>
        public string CustomerFirstName { get; set; }
		/// <summary>
		/// The last name of the customer.
		/// </summary>
        public string CustomerLastName { get; set; }
	    /// <summary>
	    /// The gender of the customer, used to properly address the customer in the mail. Possible values are:
	    /// 
	    /// 0 : Unknown 
	    /// 1 : Male 
	    /// 2 : Female
	    /// 9 : Not applicable
	    /// 
	    /// To be sure that always one of these values are used, the corresponding class with gender constants
	    /// can be used.
	    /// </summary>
		public string CustomerGender { get; set; }
		/// <summary>
		/// The country of origin of the customer.
		/// </summary>
        public string CustomerCountry { get; set; }
		/// <summary>
		/// States wether an email will be sent to the customer.
		/// </summary>
        public bool SendMail { get; set; }
		/// <summary>
		/// The email address of the customer. Required if the boolean SendMail == true.
		/// </summary>
        public string CustomerEmail { get; set; }
        public DateTime DateDue { get; set; }
    }
}
