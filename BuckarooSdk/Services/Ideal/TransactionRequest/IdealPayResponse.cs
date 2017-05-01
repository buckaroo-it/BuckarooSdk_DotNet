namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
	public class IdealPayResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Ideal;

		public string ConsumerIban { get; set; }
		public string ConsumerBic { get; set; }
		public string ConsumerName { get; set; }
		public string ConsumerIssuer { get; set; }

		public override void FillFromResponse(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromResponse(serviceResponse);
		}
	}
}
