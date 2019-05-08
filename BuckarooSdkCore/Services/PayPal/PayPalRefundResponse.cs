using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPal
{
    /// <summary>
    /// A PayPal RefundResponse does not have reponse parameters
    /// </summary>
    public class PayPalRefundResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.PayPal;
    }
}
