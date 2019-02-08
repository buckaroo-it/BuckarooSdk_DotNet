namespace BuckarooSdk.Services.CreditCards.Response
{
	public class CreditCardCaptureResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Visa;
		public string CardNumberEnding { get; set; }
		public string CardExpirationDate { get; set; }
	}
}
