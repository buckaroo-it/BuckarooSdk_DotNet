namespace BuckarooSdk.Services.CreditCards.Visa
{
    public class VisaCaptureResponse: ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
        public string CardNumberEnding { get; set; }
        public string CardExpirationDate { get; set; }
    }
}
