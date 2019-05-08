namespace BuckarooSdk.Services.Giropay
{
	public class GiropayRefundRequest
	{
		public long CustomerBankLeitzahl { get; set; }

		public string CustomerBIC { get; set; }

		public string CustomerIBAN { get; set; }

		public string CustomerAccountName { get; set; }

		public long CustomerKontonummer { get; set; }
	}
}
