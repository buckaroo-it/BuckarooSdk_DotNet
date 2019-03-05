namespace BuckarooSdk.Services.Giropay
{
	public class GiropayPayResponse
	{
		public string ConsumerBIC { get; set; }

		public string ConsumerBankleitzahl { get; set; }

		public string ConsumerAccountNumber { get; set; }

		public string ConsumerName { get; set; }

		public string ConsumerIBAN { get; set; }
	}
}
