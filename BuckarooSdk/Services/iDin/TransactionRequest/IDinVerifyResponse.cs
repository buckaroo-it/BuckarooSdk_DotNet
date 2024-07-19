using BuckarooSdk.Constants;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.iDin.TransactionRequest
{
    /// <summary>
    /// The 
	/// customer needs to be redirected to the payment environment through the returned redirectURL.
    /// </summary>
    public class IDinVerifyResponse : ActionResponse
    {
        public override ServiceNames ServiceNames => ServiceNames.IDin;
    }
}
