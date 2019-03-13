using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.MasterCard.Response
{
	/// <summary>
	/// A MasterCard Refund Response does not have response parameters
	/// </summary>
	public class MasterCardRefundResponsen : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.MasterCard;
	}
}
