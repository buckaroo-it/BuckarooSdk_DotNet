namespace BuckarooSdk.Services.Ideal.Push
{
	public class IdealPayPush : ActionPush
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Ideal;
		public string ConsumerIban { get; set; }
		public string ConsumerBic { get; set; }
		public string ConsumerName { get; set; }
		public string ConsumerIssuer { get; set; }
		
		public override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
