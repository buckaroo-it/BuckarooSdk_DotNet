using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.PaymentInitiation
{
	public class PaymentInitiationTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal PaymentInitiationTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a PaymentInitiation (PayByBank), 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An PayByBankPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(PaymentInitiationPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("PayByBank", parameters, "pay", "0");

			return configuredServiceTransaction;
		}
		/// <summary>
		/// The refund function creates a configured transaction with an PaymentInitiation (PayByBank), 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An PayByBankRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(PaymentInitiationRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("PayByBank", parameters, "refund", "0");

			return configuredServiceTransaction;
		}
	}
}
