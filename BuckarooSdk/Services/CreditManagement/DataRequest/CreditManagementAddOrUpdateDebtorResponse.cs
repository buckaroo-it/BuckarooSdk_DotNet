using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	/// <summary>
	/// For this data request type are no response parameters
	/// </summary>
	public class CreditManagementAddOrUpdateDebtorResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.CreditManagement;
	}
}
