namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    public class IdealPayRemainderResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Ideal;

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

