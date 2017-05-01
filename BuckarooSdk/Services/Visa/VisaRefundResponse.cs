namespace BuckarooSdk.Services.Visa
{
    /// <summary>
    /// A Mastercard Refund Response does not have response parameters
    /// </summary>
    public class VisaRefundResponse: ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
    }
}