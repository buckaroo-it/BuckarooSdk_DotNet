namespace BuckarooSdk.Services.CreditCards.BanContact.Request
{
	public class BancontactRefundRequest
	{
		/// <summary>
		/// The BIC of the customers account.
		/// </summary>
		public string CustomerBIC { get; set; }

		/// <summary>
		/// The IBAN of the customers account
		/// </summary>
		public string CustomerIBAN { get; set; }

		/// <summary>
		/// The account name of the customer
		/// </summary>
		public string CustomerAccountName { get; set; }
	}
}
