using BuckarooSdk.Constants;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayCaptureResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Afterpay;
	}
}
