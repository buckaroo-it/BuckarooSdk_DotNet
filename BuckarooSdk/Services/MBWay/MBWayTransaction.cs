using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.MBWay
{
	public class MBWayTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal MBWayTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an MBWayPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An MBWayPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(MBWayPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MBWay", parameters, "pay", "0");

			return configuredServiceTransaction;
		}
		/// <summary>
		/// The refund function creates a configured transaction with an MBWayRefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An MBWayRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(MBWayRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MBWay", parameters, "refund", "0");

			return configuredServiceTransaction;
		}
	}
}
