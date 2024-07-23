using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Multibanco
{
	public class MultibancoTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal MultibancoTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an MultibancoPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An MultibancoPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(MultibancoPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Multibanco", parameters, "pay", "0");

			return configuredServiceTransaction;
		}
		/// <summary>
		/// The refund function creates a configured transaction with an MultibancoRefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An MultibancoRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(MultibancoRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Multibanco", parameters, "refund", "0");

			return configuredServiceTransaction;
		}
	}
}
