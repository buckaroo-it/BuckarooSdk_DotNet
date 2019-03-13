using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.Visa.Response
{
    public class VisaCaptureResponse: ActionResponse
    {
		public override ServiceNames ServiceNames => ServiceNames.Visa;

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
