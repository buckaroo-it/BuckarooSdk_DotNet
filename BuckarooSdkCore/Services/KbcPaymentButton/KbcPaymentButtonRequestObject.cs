using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.KbcPaymentButton
{
	public class KbcPaymentButtonRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }
		private ConfiguredDataRequest ConfiguredDataRequest { get; }

		internal KbcPaymentButtonRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		internal KbcPaymentButtonRequestObject(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an KbcPaymentButtonPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KbcPaymentButtonPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(KbcPaymentButtonPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction =
				new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("kbcpaymentbutton", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an KbcPaymentButtonRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KbcPaymentButtonRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(KbcPaymentButtonRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction =
				new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("kbcpaymentbutton", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRemainder function creates a configured transaction with an KbcPaymentButtonPayRemainderRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KbcPaymentButtonPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(KbcPaymentButtonPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction =
				new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("kbcpaymentbutton", parameters, "PayRemainder");

			return configuredServiceTransaction;
		}
	}
}
