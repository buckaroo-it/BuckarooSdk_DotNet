using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.CreditCards.AmericanExpress.Request
{
	public class AmericanExpressTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

		internal AmericanExpressTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an AmericanExpressPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(AmericanExpressPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "Pay", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an AmericanExpressRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(AmericanExpressRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "Refund", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Authorize function creates a configured transaction with an AmericanExpressAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Authorize(AmericanExpressAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "Authorize", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Capture function creates a configured transaction with an AmericanExpressCaptureRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressCaptureRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Capture(AmericanExpressCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "Capture", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRecurrent function creates a configured transaction with an AmericanExpressPayRecurrentRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressPayRecurrentRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRecurrent(AmericanExpressPayRecurrentRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "PayRecurrent", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayRemainder function creates a configured transaction with an AmericanExpressPayRemainderRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(AmericanExpressPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "PayRemainder", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayEncrypted function creates a configured transaction with an AmericanExpressPayEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressPayEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayEncrypted(AmericanExpressPayEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "PayEncrypted", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The AuthorizeEncrypted function creates a configured transaction with an AmericanExpressAuthorizeEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AmericanExpressAuthorizeEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction AuthorizeEncrypted(AmericanExpressAuthorizeEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("AmericanExpress", parameters, "AuthorizeEncrypted", "1");

			return configuredServiceTransaction;
		}


	}
}
