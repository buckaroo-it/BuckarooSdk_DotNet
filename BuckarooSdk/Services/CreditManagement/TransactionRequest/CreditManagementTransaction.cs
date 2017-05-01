using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.CreditManagement.TransactionRequest
{
	public class CreditManagementTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredAdditionalTransaction ConfiguredTransaction { get; set; }

		internal CreditManagementTransaction(ConfiguredAdditionalTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		#region actions

		/// <summary>
		/// The CreateCombinedInvoice function creates a configured transaction with an 
		/// CreditManagementInvoiceRequest, that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditManagementInvoiceRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CreateCombinedInvoice(CreditManagementInvoiceRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddAdditionalService("CreditManagement3", parameters, "CreateCombinedInvoice", "1");

			return configuredServiceTransaction;
		}

		#endregion
	}
}
