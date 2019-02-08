namespace BuckarooSdk.Services.CreditCards.Response
{
	public class CreditCardPayResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
		public string CardExpirationDate { get; set; }
		public string CardEnrolled { get; set; }
		public string CardAuthentication { get; set; }
		public string CardNumberEnding { get; set; }
	}
}
