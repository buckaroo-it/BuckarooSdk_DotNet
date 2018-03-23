namespace BuckarooSdk.Services.Visa
{
    public class VisaAuthorizeResponse : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
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
