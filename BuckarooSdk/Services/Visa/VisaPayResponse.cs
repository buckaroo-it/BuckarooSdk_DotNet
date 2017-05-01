namespace BuckarooSdk.Services.Visa
{
    public class VisaPayResponse: ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
        public string CardExpirationDate { get; set; }
        public string CardEnrolled { get; set; }
        public string CardAuthentication { get; set; }
        public string CardNumberEnding { get; set; }
    }
}
