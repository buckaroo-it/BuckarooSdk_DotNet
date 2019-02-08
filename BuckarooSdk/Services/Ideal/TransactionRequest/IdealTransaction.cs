using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
	/// <summary>
	/// The Transaction class of payment method type: iDEAL.
	/// </summary>
    public class IdealTransaction
    {
		/// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get;}

        internal IdealTransaction(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The pay function creates a configured transaction with an IdealPayRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">An IdealPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(IdealPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Ideal", parameters, "pay", "2");

            return configuredServiceTransaction;
        }
        /// <summary>
		/// The refund function creates a configured transaction with an IdealRefundRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealRefundRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction Refund(IdealRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Ideal", parameters, "refund", "2");

            return configuredServiceTransaction;
        }
        /// <summary>
		/// The pay remainder function creates a configured transaction with an IdealPayRemainderRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealPayRemainderRequest</param>
		/// <returns></returns>
        public ConfiguredServiceTransaction PayRemainder(IdealPayRemainderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Ideal", parameters, "payremainder", "2");

            return configuredServiceTransaction;
        }
    }
}
