using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.Push
{
	public class IdealRefundPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.Ideal;
	}
}