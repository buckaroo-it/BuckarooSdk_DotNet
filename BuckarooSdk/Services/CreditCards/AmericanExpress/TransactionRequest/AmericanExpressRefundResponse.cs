using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.AmericanExpress.TransactionRequest
{
	/// <summary>
	/// An American Express refund does not have response parameters
	/// </summary>
	public class AmericanExpressRefundResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.AmericanExpress;
	}
}
