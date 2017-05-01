using System;

namespace BuckarooSdk.Services.AmericanExpress.TransactionRequest
{
	public class AmericanExpressAuthorizeResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.AmericanExpress;
		
		/// <summary>
		/// The expiration date of the card that is used by the consumer
		/// </summary>
		public DateTime CardExpirationDate { get; set; }

		/// <summary>
		/// The end numbers of the card dat is used by the consumer.
		/// </summary>
		public string CardNumberEnding { get; set; }
	}
}
