namespace BuckarooSdk.Services.Transfer.Push
{
	public class TransferRefundPush : ActionPush
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.PayPal;

		public string CustomerAccountName { get; set; }
		public string CustomerIban { get; set; }
		public string CustomerBic { get; set; }
	}
}