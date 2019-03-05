using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPal.Push
{
	public class PayPalPayRecurrentPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.PayPal;

		public string PayerStatus { get; set; }
		public string PayerEmail { get; set; }
		public string PayerCountry { get; set; }
		public string PayerFirstName { get; set; }
		public string PayerLastName { get; set; }
		public string PayerTransactionId { get; set; }
	}
}