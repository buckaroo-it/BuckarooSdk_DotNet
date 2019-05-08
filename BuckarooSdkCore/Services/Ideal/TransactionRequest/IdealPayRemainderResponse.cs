using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    public class IdealPayRemainderResponse : ActionResponse
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

