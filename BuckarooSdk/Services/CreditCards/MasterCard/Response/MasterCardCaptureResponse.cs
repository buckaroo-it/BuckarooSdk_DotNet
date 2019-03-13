using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards.MasterCard.Response
{
    public class MasterCardCaptureResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.MasterCard;

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
