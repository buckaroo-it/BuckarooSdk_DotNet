namespace BuckarooSdk.Services.Sofort
{
	public class SofortRefundRequest
	{
		/// <summary>
		/// BIC code of the customers' bank.
		/// </summary>
		public string CustomerBIC { get; set; }

		/// <summary>
		/// IBAN bank account number of the customer.
		/// </summary>
		public string CustomerIBAN { get; set; }

		/// <summary>
		/// The account holder beneficiary name
		/// </summary>
		public string CustomerAccountName { get; set; }

		/// <summary>
		/// The account number
		/// </summary>
		public long CustomerKontoNummer { get; set; }

		/// <summary>
		/// The german bank code identifying the customer bank.
		/// </summary>
		public long CustomerBankLeitzahl { get; set; }
	}
}
