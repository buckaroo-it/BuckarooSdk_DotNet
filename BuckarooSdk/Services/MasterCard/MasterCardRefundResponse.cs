namespace BuckarooSdk.Services.MasterCard
{
    /// <summary>
    /// A Mastercard Refund Response does not have response parameters
    /// </summary>
    public class MasterCardRefundResponsen : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.MasterCard;
    }
}
