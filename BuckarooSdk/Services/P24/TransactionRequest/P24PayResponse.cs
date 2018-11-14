namespace BuckarooSdk.Services.P24.TransactionRequest
{
	/// <summary>
	/// If the request has a valid structure and a valid signature, a transaction will be created in the Payment Engine and a 
	/// response will be returned. In this case, an additional action is required before the transaction can be completed. The 
	/// customer needs to be redirected to the payment environment through the returned redirectURL.
	/// </summary>
	public class P24PayResponse
	{ 
		//no output parameters
	}
}