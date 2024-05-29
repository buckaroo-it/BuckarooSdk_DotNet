
namespace BuckarooSdk.Services.Blik
{
	public class BlikRefundResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Blik;

		public string BankStatementId { get; set; }
		public string Processed { get; set; }
	}
}
