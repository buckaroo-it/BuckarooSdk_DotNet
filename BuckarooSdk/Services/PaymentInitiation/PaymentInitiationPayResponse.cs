
namespace BuckarooSdk.Services.PaymentInitiation
{
	public class PaymentInitiationPayResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.PayByBank;

		public string ConsumerIssuer { get; set; }
		public string ConsumerBic { get; set; }
	}
}
