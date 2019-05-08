using BuckarooSdk.Transaction;


namespace BuckarooSdk.Services.SimpleSepaDirectDebit
{
    public class SimpleSepaDirectDebitTransaction
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; set; }

        internal SimpleSepaDirectDebitTransaction(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The pay function creates a configured transaction with an SimpleSepaDirectDebitPayRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An SimpleSepaDirectDebitPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(SimpleSepaDirectDebitPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SimpleSepaDirectDebit", parameters, "pay", "2");

            return configuredServiceTransaction;
        }
        /// <summary>
		/// The refund function creates a configured transaction with an SimpleSepaDirectDebitRefundRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An SimpleSepaDirectDebitRefundRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction Refund(SimpleSepaDirectDebitRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("SimpleSepaDirectDebit", parameters, "refund", "2");

            return configuredServiceTransaction;
        }
    }
}
