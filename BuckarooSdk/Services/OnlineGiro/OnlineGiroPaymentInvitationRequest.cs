using System;

namespace BuckarooSdk.Services.OnlineGiro
{

	public class OnlineGiroPaymentInvitationRequest
	{
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
		public int CustomerGender { get; set; }

		/// <summary>
		/// The first name of the customer.
		/// </summary>
		public string CustomerFirstName { get; set; }

		/// <summary>
		/// The last name of the customer.
		/// </summary>
		public string CustomerLastName { get; set; }

		/// <summary>
		/// The email address of the customer where the email needs to be send to.
		/// </summary>
		public string CustomerEmail { get; set; }

		/// <summary>
		/// The date you wish to have the OnlineGiro payment invitation expired.
		/// </summary>
		public DateTime ExpirationDate { get; set; }

		/// <summary>
		/// The file name of a previously uploaded attachment.
		/// </summary>
		public string Attachment { get; set; }
	}
}
