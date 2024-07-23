namespace BuckarooSdk.Services.PaymentInitiation
{
	public class PaymentInitiationPayRequest
	{
		/// <summary>
		/// The bank name (issuer).
		/// </summary>
		public string Issuer { get; set; }

		/// <summary>
		/// The bank country code.
		/// </summary>
		public string CountryCode { get; set; }
	}
}
