using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Capayable
{
	public class CapayableRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal CapayableRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an CapayablePayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CapayablePayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(CapayablePayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("capayable", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an CapayableRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CapayableRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(CapayableRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("capayable", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayInInstallments function creates a configured transaction with an CapayablePayInInstallmentsRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CapayablePayInInstallmentsRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayInInstallments(CapayablePayInInstallmentsRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("capayable", parameters, "PayInInstallments");

			return configuredServiceTransaction;
		}
	}
}
