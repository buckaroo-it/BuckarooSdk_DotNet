using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Ippies
{
	public class IppiesRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal IppiesRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an IppiesPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A IppiesPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(IppiesPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("ippies", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an IppiesRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A IppiesRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(IppiesRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("ippies", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRemainder function creates a configured transaction with an IppiesPayRemainderRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A IppiesPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(IppiesPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("ippies", parameters, "PayRemainder");

			return configuredServiceTransaction;
		}
	}
}
