using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Response
{
	public class CreditCardPayRecurrentResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.CreditCard;

		/// <summary>
		/// Credit card expiration date.
		/// </summary>
		public string CardExpirationDate { get; set; }
	}
}
