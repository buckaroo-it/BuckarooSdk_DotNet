using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.INGHomePay
{
	public class INGHomePayRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal INGHomePayRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an INGHomePayPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A INGHomePayPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(INGHomePayPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("inghomepay", parameters, "Pay");

			return configuredServiceTransaction;
		}
	}
}
