namespace BuckarooSdk.Services.MasterCard
{
    public class MasterCardPayRecurrentResponse : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.MasterCard;
        public string CardExpirationDate { get; set; }
    }
}
