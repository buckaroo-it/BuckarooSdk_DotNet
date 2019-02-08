namespace BuckarooSdk.Services.CreditCards.Response
{
	public class CreditCardPayRecurrentResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
		public string CardExpirationDate { get; set; }
	}
}
