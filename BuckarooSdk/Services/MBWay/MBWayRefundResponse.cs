
namespace BuckarooSdk.Services.MBWay
{
	public class MBWayRefundResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.MBWay;

		public string BankStatementId { get; set; }
		public string Processed { get; set; }
	}
}
