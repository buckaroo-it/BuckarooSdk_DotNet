
namespace BuckarooSdk.Services.Multibanco
{
	public class MultibancoRefundResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Multibanco;

		public string Processed { get; set; }
	}
}
