using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Giropay
{
	public class GiropayTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal GiropayTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an GiropayPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A GiropayPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(GiropayPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("giropay", parameters, "Pay", "2");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an GiropayRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A GiropayRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(GiropayRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("giropay", parameters, "Refund", "2");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRemainder function creates a configured transaction with an GiropayPayRemainderRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A GiropayPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(GiropayPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("giropay", parameters, "PayRemainder", "2");

			return configuredServiceTransaction;
		}


	}
}
