using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPal
{
    /// <summary>
    /// A PayPal CancelAuthorizeResponse does not have response parameters
    /// </summary>
    public class PayPalCancelAuthorizeResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.PayPal;
    }
}
