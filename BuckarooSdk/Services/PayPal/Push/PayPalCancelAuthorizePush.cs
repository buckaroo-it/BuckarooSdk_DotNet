using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPal.Push
{
	public class PayPalCancelAuthorizePush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.PayPal;
	}
}
