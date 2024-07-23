
namespace BuckarooSdk.Services.PaymentInitiation
{
	public class PaymentInitiationRefundResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.PayByBank;

		public string CustomerAccountName { get; set; }
		public string CustomerIBAN { get; set; }
		public string Processed { get; set; }
	}
}
