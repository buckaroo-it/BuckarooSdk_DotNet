using BuckarooSdk.Constants;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayAuthorizeResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Afterpay;
	}
}
