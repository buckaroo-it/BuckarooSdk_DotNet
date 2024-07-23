using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Blik
{
	public class BlikTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal BlikTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an BlikPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An BlikPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(BlikPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("BLIK", parameters, "pay", "0");

			return configuredServiceTransaction;
		}
		/// <summary>
		/// The refund function creates a configured transaction with an BlikRefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An BlikRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(BlikRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("BLIK", parameters, "refund", "0");

			return configuredServiceTransaction;
		}
	}
}
