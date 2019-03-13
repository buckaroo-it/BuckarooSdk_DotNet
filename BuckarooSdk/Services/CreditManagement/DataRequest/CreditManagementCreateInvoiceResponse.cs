using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	public class CreditManagementCreateInvoiceResponse : ActionResponse
	{
		// No response Parameters
		public override ServiceNames ServiceNames => ServiceNames.CreditManagement;

		public string InvoiceKey { get;set; }
	}
}
