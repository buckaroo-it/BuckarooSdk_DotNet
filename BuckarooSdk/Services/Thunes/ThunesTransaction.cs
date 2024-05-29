using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Thunes
{
	public class ThunesTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal ThunesTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an SimpleSepaDirectDebitPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An SimpleSepaDirectDebitPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(ThunesBaseRequest request, ThunesServiceType serviceName)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceName.ToString(), parameters, "pay", "0");

			return configuredServiceTransaction;
		}
	}
}
