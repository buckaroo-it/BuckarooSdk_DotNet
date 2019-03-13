namespace BuckarooSdk.Services.Giropay
{
	public class GiropayPayRemainderRequest
	{
		public string BIC { get; set; }

		public long BankLeitzahl { get; set; }
	}
}
