using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Transfer.TransactionRequest
{
    public class TransferTransaction
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; set; }

        internal TransferTransaction(ConfiguredTransaction baseTransaction)
        {
            this.ConfiguredTransaction = baseTransaction;
        }

        /// <summary>
		/// The pay function creates a configured transaction with a TransferPayRequest, 
        /// that is ready to be executed.
		/// </summary>
		/// <param name="request">A TransferPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(TransferPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Transfer", parameters, "pay");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The refund function creates a configured transaction with a TransferPayRequest, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A TransferPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Refund(TransferRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("Transfer", parameters, "refund");

            return configuredServiceTransaction;
        }
    }
}
