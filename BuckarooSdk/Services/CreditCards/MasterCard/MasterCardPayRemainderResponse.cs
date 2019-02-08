namespace BuckarooSdk.Services.CreditCards.MasterCard
{
    public class MasterCardPayRemainderResponse : ActionResponse
    {

	    public override ServiceEnum ServiceEnum => ServiceEnum.MasterCard;
        public string CardExpirationDate { get; set; }
        public string CardEnrolled { get; set; }
        public string CardAuthentication { get; set; }
        public string CardNumberEnding { get; set; }
    }
}
