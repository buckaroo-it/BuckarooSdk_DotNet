namespace BuckarooSdk.Services.Giropay
{
	public class GiropayPayResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Giropay;

		public string ConsumerBIC { get; set; }
	}
}
