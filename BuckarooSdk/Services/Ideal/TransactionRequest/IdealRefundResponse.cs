namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    /// <summary>
    /// An iDEAL refund does not have reponse parameters
    /// </summary>
    public class IdealRefundResponse : ActionResponse
    {
		public override ServiceEnum ServiceEnum => ServiceEnum.Ideal;
    }
}
