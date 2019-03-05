using System;

namespace BuckarooSdk.Services.CreditCards.AmericanExpress.Request
{
	public class AmericanExpressAuthorizeResponse
	{
		/// <summary>
		/// Credit card expiration date.
		/// </summary>
		public DateTime CardExpirationDate { get; set; }

		/// <summary>
		/// Last 4 digits of the creditcard number.
		/// </summary>
		public string CardNumberEnding { get; set; }
	}
}
