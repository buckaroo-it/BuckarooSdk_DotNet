using BuckarooSdk.Constants;

namespace BuckarooSdk.Services.Giropay
{
	public class GiropayRefundResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Giropay;
	}
}
