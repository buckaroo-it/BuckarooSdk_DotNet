using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPal.Push
{
	public class PayPalRefundPush: ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.PayPal;
	}
}