namespace BuckarooSdk.Services.CreditCards.Maestro
{
	public class MaestroPayRemainderResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Maestro;
		public string CardExpirationDate { get; set; }
	}
}
