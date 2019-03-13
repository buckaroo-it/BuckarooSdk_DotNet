using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Visa.Response
{
	/// <summary>
	/// A MasterCard Refund Response does not have response parameters
	/// </summary>
	public class VisaRefundResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Visa;
	}
}