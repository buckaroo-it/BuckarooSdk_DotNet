using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Visa.Response
{
    public class VisaAuthorizeResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.Visa;

		/// <summary>
		/// The expiration date of the card used by the customer.
		/// </summary>
        public string CardExpirationDate { get; set; }

		/// <summary>
		/// States wether the card is enrolled.
		/// </summary>
        public string CardEnrolled { get; set; }

		/// <summary>
		/// The card authentication reference.
		/// </summary>
        public string CardAuthentication { get; set; }

		/// <summary>
		/// The last few digits of the card used by the customer.
		/// </summary>
        public string CardNumberEnding { get; set; }
    }
}
