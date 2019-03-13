using System;

namespace BuckarooSdk.Services.CreditCards.BanContact.Response
{
	public class BancontactPayRemainderResponse
	{
		/// <summary>
		/// The authentication status.
		/// </summary>
		public string CardAuthentication { get; set; }

		/// <summary>
		/// Last 4 digits of the creditcard number.
		/// </summary>
		public string CardNumberEnding { get; set; }

		/// <summary>
		/// The expiration date of the card that is used by the consumer
		/// </summary>
		public DateTime CardExpirationDate { get; set; }

		/// <summary>
		/// The IBAN of the customers account
		/// </summary>
		public string CustomerIBAN { get; set; }

		/// <summary>
		/// The enrolled status.
		/// </summary>
		public string CardEnrolled { get; set; }
	}
}
