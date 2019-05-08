using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Payconiq.TransactionRequest
{
	/// <summary>
	/// The Payconiq refund response class, where customer values can be read from.
	/// </summary>
	public class PayconiqRefundResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Payconiq;
	}
}
