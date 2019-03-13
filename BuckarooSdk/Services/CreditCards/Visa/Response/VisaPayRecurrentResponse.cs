using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Visa.Response
{
	public class VisaPayRecurrentResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Visa;

		/// <summary>
		/// Credit card expiration date.
		/// </summary>
		public string CardExpirationDate { get; set; }
	}
}
