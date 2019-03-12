namespace BuckarooSdk.Services.EPS
{
	public class EPSRefundRequest
	{
		/// <summary>
		/// The beneficiary of the bank account from which the payment was made.
		/// </summary>
		public string CustomerAccountName { get; set; }

		/// <summary>
		/// The international bank account number (iban code) of the bank of the consumer. Please note: This field is optional. In some countries, 
		/// banks are not allowed to provide this information to third parties.
		/// </summary>
		public string CustomerIBAN { get; set; }

		/// <summary>
		/// The BIC of the customers account.
		/// </summary>
		public string CustomerBIC { get; set; }
	}
}
