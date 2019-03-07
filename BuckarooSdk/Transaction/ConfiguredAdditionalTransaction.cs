using BuckarooSdk.Services.CreditManagement.TransactionRequest;

namespace BuckarooSdk.Transaction
{
	public class ConfiguredAdditionalTransaction
	{
		internal RequestObject BaseTransaction { get; private set; }
		
		public ConfiguredAdditionalTransaction(RequestObject transactionRequest)
		{
			this.BaseTransaction = transactionRequest;
		}

		#region "Services"

		public CreditManagementTransaction CreditManagement()
		{
			return new CreditManagementTransaction(this);
		}

		#endregion
	}
}
