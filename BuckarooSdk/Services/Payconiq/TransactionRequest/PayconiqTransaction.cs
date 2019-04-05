using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Payconiq.TransactionRequest
{
	public class PayconiqTransaction
	{
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal PayconiqTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an PayconiqPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A PayconiqPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(PayconiqPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Payconiq", parameters, "pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The refund function creates a configured transaction with an PayconiqRefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A PayconiqRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(PayconiqRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Payconiq", parameters, "refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an PayconiqPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A PayconiqPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(PayconiqPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Payconiq", parameters, "pay");

			return configuredServiceTransaction;
		}
	}
}
