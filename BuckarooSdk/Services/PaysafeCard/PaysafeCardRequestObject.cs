using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.PaysafeCard
{
	public class PaysafeCardRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal PaysafeCardRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an PaysafeCardPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A PaysafeCardPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(PaysafeCardPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("paysafecard", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRemainder function creates a configured transaction with an PaysafeCardPayRemainderRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A PaysafeCardPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(PaysafeCardPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("paysafecard", parameters, "PayRemainder");

			return configuredServiceTransaction;
		}
	}
}
