namespace BuckarooSdk.Services.Transfer.TransactionRequest
{
    /// <summary>
    /// A Transfer refund does not have reponse parameters
    /// </summary>
    public class TransferRefundResponse : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.Transfer;
    }
}
