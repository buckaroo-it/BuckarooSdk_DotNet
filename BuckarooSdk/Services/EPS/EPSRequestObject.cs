using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.EPS
{
    public class EPSRequestObject
    {
        /// <summary>
        /// The configured transaction
        /// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; }

        internal EPSRequestObject(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The Pay function creates a configured transaction with an EPSPayRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EPSPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(EPSPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("eps", parameters, "Pay");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The Refund function creates a configured transaction with an EPSRefundRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EPSRefundRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Refund(EPSRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("eps", parameters, "Refund");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The PayRemainder function creates a configured transaction with an EPSPayRemainderRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EPSPayRemainderRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayRemainder(EPSPayRemainderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("eps", parameters, "PayRemainder");

            return configuredServiceTransaction;
        }
    }
}
