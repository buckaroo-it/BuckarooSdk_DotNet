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
