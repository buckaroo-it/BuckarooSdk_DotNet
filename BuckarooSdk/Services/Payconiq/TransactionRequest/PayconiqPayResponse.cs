namespace BuckarooSdk.Services.Payconiq.TransactionRequest
{
	/// <summary>
	/// The payconiq pay response class, where customer values of the request can be read from.
	/// </summary>
	public class PayconiqPayResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Payconiq;

		public string QrUrl { get; set; }
		public string PayconiqUrl { get; set; }
		public string PayconiqIosUrl { get; set; }
		public string PayconiqAndroidUrl { get; set; }
		public string TransactionId { get; set; }
	}
}
