using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
	/// <summary>
	/// If the request has a valid structure and a valid signature, a transaction will be created in the Payment Engine and a response 
	/// will be returned. In this case, an additional action is required before the transaction can be completed. The customer needs to 
	/// be redirected to the payment environment through the returned redirectURL.
	/// </summary>
	public class IdealPayResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Ideal;

		/// <summary>
		/// This is the iDEAL transaction ID.
		/// </summary>
		public string TransactionId { get; set; }

		/// <summary>
		/// The name of the issuer (bank) of the consumer.
		/// </summary>
		public string ConsumerIssuer { get; set; }
	}
}
