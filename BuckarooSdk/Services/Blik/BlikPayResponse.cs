
namespace BuckarooSdk.Services.Blik
{
	public class BlikPayResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Blik;

		public string BankStatementId { get; set; }
	}
}
