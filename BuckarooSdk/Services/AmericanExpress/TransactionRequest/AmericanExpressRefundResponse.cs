namespace BuckarooSdk.Services.AmericanExpress.TransactionRequest
{
	/// <summary>
	/// An American Express refund does not have response parameters
	/// </summary>
	public class AmericanExpressRefundResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.AmericanExpress;
	}
}
