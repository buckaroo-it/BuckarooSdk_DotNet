using BuckarooSdk.Services.CreditManagement.TransactionRequest;

namespace BuckarooSdk.Transaction
{
	public class ConfiguredAdditionalTransaction
	{
		internal TransactionRequest BaseTransaction { get; private set; }
		
		public ConfiguredAdditionalTransaction(TransactionRequest transactionRequest)
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
