using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Response
{
	public class CreditCardPayResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.CreditCard;

		/// <summary>
		/// Credit card expiration date.
		/// </summary>
		public string CardExpirationDate { get; set; }

		/// <summary>
		/// The enrolled status.
		/// </summary>
		public string CardEnrolled { get; set; }

		/// <summary>
		/// The authentication status.
		/// </summary>
		public string CardAuthentication { get; set; }

		/// <summary>
		/// Last 4 digits of the creditcard number.
		/// </summary>
		public string CardNumberEnding { get; set; }
	}
}
