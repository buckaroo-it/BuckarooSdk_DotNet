using BuckarooSdk.Services.CreditManagement.TransactionRequest;

namespace BuckarooSdk.Transaction
{
	public class ConfiguredAdditionalTransaction
	{
		internal IRequestObject BaseTransaction { get; private set; }
		
		public ConfiguredAdditionalTransaction(IRequestObject transactionRequest)
		{
			this.BaseTransaction = transactionRequest;
		}

		#region "ServiceList"

		public CreditManagementTransaction CreditManagement()
		{
			return new CreditManagementTransaction(this);
		}

		#endregion
	}
}
