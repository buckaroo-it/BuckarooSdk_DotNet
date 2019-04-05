using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.CreditCards.AmericanExpress.TransactionRequest
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
        /// The pay function creates a configured transaction with an IdealPayRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An IdealPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(AmericanExpressPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("amex", parameters, "pay");

            return configuredServiceTransaction;
        }
        /// <summary>
		/// The refund function creates a configured transaction with an IdealRefundRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealRefundRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction Refund(AmericanExpressRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("amex", parameters, "refund");

            return configuredServiceTransaction;
        }

		/// <summary>
		/// The pay remainder function creates a configured transaction with an IdealPayRemainderRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealPayRemainderRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction Authorize(AmericanExpressAuthorizeRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("amex", parameters, "authorize");

            return configuredServiceTransaction;
        }

		/// <summary>
		/// The pay remainder function creates a configured transaction with an IdealPayRemainderRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealPayRemainderRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction PayRecurrent(AmericanExpressPayRecurrentRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("amex", parameters, "payrecurrent");

            return configuredServiceTransaction;
        }

        /// <summary>
		/// The pay remainder function creates a configured transaction with an IdealPayRemainderRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealPayRemainderRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction PayRemainder(AmericanExpressPayRemainderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("amex", parameters, "payremainder");

            return configuredServiceTransaction;
        }

	}
}
