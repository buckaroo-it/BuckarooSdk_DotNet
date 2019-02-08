using BuckarooSdk.Services.CreditCards.Request;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.CreditCards
{
	public class CreditCardTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal CreditCardTransaction(ConfiguredTransaction baseTransaction)
		{
			this.ConfiguredTransaction = baseTransaction;
		}

		/// <summary>
		/// The pay function creates a configured creditcard transaction,
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(CreditCardPayRequest request)
		{
			var serviceCode = string.Empty;

			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceCode, parameters, "pay");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction Refund(CreditCardRefundRequest request)
		{
			var serviceCode = string.Empty;

			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceCode, parameters, "refund");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction Authorize(CreditCardAuthorizeRequest request)
		{
			var serviceCode = string.Empty;

			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceCode, parameters, "authorize");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction Capture(CreditCardCaptureRequest request)
		{
			var serviceCode = string.Empty;

			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceCode, parameters, "capture");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction PayRecurrent(CreditCardPayRecurrentRequest request)
		{
			var serviceCode = string.Empty;

			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceCode, parameters, "payrecurrent");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction PayRemainder(CreditCardPayRemainderRequest request)
		{
			var serviceCode = string.Empty;

			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(serviceCode, parameters, "payremainder");

			return configuredServiceTransaction;
		}
	}
}
