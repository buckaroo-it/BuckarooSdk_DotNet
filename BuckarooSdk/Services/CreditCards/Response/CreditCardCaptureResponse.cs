using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Response
{
	public class CreditCardCaptureResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.CreditCard;

		/// <summary>
		/// Last 4 digits of the creditcard number.
		/// </summary>
		public string CardNumberEnding { get; set; }

		/// <summary>
		/// Last 4 digits of the creditcard number.
		/// </summary>
		public string CardExpirationDate { get; set; }
	}
}
