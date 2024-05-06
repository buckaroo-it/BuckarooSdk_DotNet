using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Banking
{
    /// <summary>
    /// The Transaction class of payment method type: Banking.
    /// </summary>
    public class BankingRequestObject
    {
        private ConfiguredTransaction ConfiguredTransaction { get; }
        internal BankingRequestObject(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The PaymentOrder function creates a configured transaction with an Banking PaymentOrderRequest,
        /// that is ready to be executed.
        /// </summary>
        public ConfiguredServiceTransaction PaymentOrder(BankingPaymentOrderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Banking", parameters, "PaymentOrder");
            return configuredServiceTransaction;
        }
        
        /// <summary>
        /// The InstantPaymentOrder function creates a configured transaction with an Banking InstantPaymentOrderRequest,
        /// that is ready to be executed.
        /// </summary>
        public ConfiguredServiceTransaction InstantPaymentOrder(BankingInstantPaymentOrderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Banking", parameters, "InstantPaymentOrder");
            return configuredServiceTransaction;
        }
    }
}
