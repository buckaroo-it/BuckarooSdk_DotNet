namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    /// <summary>
    /// The action for iDEAL Fast_Checkout is PayFastCheckout. This action does not require the consumer's issuing bank as input.
    /// An iDEAL payment has a lifetime of 15 minutes; this means that the payment must be completed within 15 minutes or it will expire. 
    /// In the event that the consumer irregularly ends the payment process (for example,
    /// by closing the browser window before returning to the webshop), the payment status will be retrieved from the acquirer as soon as 
    /// the 15 minute lifespan is expired and the merchant webshop is updated via a push response. It is therefore recommended to enable the 
    /// push response in the Payment Plaza when implementing iDEAL. A successful payment will include all the enum items in the OutputParameters.cs under the Ideal > Constants folder.
    /// </summary>
    public class IdealPayFastCheckoutRequest
    {

    }
}
