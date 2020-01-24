namespace BuckarooSdk.Services.Afterpay
{/// <summary>
/// 
/// </summary>
	public class AfterpayCancelAuthorizeRequest
	{
		//this service action does not require any service specific paramters, only:
		// - OriginalTransactionKey: This is a basic parameter. Transaction key of the Authorize transaction.
		// - Invoice: This is a basic parameter. Invoice number given to the CancelAuthorize transaction. Strongly adviced to use the same invoice number of the Authorize transaction
	}
}
