using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitTransaction
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; set; }

        internal SepaDirectDebitTransaction(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The authorize function creates a configured transaction with an SepaDirectDebitAuthorizeRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An SepaDirectDebitAuthorizeRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Authorize(SepaDirectDebitAuthorizeRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SepaDirectDebit", parameters, "Authorize");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The pay function creates a configured transaction with an SepaDirectDebitPayRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An SepaDirectDebitPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(SepaDirectDebitPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SepaDirectDebit", parameters, "pay");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The pay extra info function creates a configured transaction with an SepaDirectDebitExtraInfoRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An SepaDirectDebitExtraInfoRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayExtraInfo(SepaDirectDebitExtraInfoRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SepaDirectDebit", parameters, "Pay,ExtraInfo");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The pay recurrent function creates a configured transaction with an SepaDirectDebitPayRecurrentRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An SepaDirectDebitPayRecurrentRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayRecurrent(SepaDirectDebitPayRecurrentRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SepaDirectDebit", parameters, "payrecurrent");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The pay with emandate function creates a configured transaction with an SepaDirectDebitPayWithEmandateRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An SepaDirectDebitPayWithEmandateRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayWithEMandate(SepaDirectDebitPayWithEmandateRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SepaDirectDebit", parameters, "PayWithEmandate");

            return configuredServiceTransaction;
        }

        /// <summary>
		/// The refund function creates a configured transaction with an SepaDirectDebitRefundRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An SepaDirectDebitRefundRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction Refund(SepaDirectDebitRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SepaDirectDebit", parameters, "refund");

            return configuredServiceTransaction;
        }
    }
}
