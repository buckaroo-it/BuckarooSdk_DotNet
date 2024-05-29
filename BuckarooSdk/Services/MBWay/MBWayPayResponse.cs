
namespace BuckarooSdk.Services.MBWay
{
	public class MBWayPayResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.MBWay;

		public string BankStatementId { get; set; }
	}
}
