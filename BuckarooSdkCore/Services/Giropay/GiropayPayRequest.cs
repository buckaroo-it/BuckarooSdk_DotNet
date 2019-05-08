namespace BuckarooSdk.Services.Giropay
{
	public class GiropayPayRequest
	{
		public string BIC { get; set; }

		public string CustomerIBAN { get; set; }

		public long BankLeitzahl { get; set; }
	}
}
