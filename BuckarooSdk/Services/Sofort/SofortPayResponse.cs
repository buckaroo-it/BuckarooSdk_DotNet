namespace BuckarooSdk.Services.Sofort
{
	public class SofortPayResponse
	{
		/// <summary>
		/// IBAN bank account number of the customer.
		/// </summary>
		public string CustomerIBAN { get; set; }

		/// <summary>
		/// BIC code of the customers' bank.
		/// </summary>
		public string CustomerBIC { get; set; }
	}
}
