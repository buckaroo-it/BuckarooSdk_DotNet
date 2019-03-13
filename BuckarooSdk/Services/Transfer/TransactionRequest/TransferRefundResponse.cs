using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Transfer.TransactionRequest
{
    /// <summary>
    /// A Transfer refund does not have reponse parameters
    /// </summary>
    public class TransferRefundResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.Transfer;
    }
}
