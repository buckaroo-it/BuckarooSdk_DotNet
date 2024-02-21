using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.InThree
{
    /// <summary>
    /// The Transaction class of payment method type: In3.
    /// </summary>
    public class InThreeTransaction
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; }
        internal InThreeTransaction(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The pay function creates a configured transaction with an InThreePayRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An InThreePayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(InThreePayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("In3", parameters, "Pay");

            return configuredServiceTransaction;
        }

        /// <summary>
		/// The Refund function creates a configured transaction with an InThreeRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A InThreeRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(InThreeRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("In3", parameters, "Refund");

            return configuredServiceTransaction;
        }
    }
}
