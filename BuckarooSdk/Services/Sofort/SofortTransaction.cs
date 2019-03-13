using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Sofort
{
	public class SofortTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal SofortTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an SofortPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A SofortPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(SofortPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("sofortueberweisung", parameters, "Pay", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an SofortRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A SofortRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(SofortRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("sofortueberweisung", parameters, "Refund", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRemainder function creates a configured transaction with an SofortPayRemainderRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A SofortPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(SofortPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("sofortueberweisung", parameters, "PayRemainder", "1");

			return configuredServiceTransaction;
		}
	}
}
