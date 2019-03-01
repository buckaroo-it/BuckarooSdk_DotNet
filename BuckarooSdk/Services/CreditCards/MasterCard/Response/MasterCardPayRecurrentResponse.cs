using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.MasterCard.Response
{
	public class MasterCardPayRecurrentResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.MasterCard;

		/// <summary>
		/// Credit card expiration date.
		/// </summary>
		public string CardExpirationDate { get; set; }
	}
}
