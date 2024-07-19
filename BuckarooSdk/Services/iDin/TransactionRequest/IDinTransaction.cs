using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.iDin.TransactionRequest
{
    /// <summary>
    /// The Transaction class of iDin.
    /// </summary>
    public class IDinTransaction
    {
        /// <summary>
        /// The configured transaction
        /// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; }
        internal IDinTransaction(ConfiguredTransaction configuredTransaction)
        {
            ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The Identify function creates a configured transaction with an IDinIdentifyRequest, that is ready to be executed.
        /// </summary>
        /// <param name="request">An IDinIdentifyRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Identify(IDinIdentifyRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("iDin", parameters, "identify");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The Verify function creates a configured transaction with an IDinVerifyRequest, that is ready to be executed.
        /// </summary>
        /// <param name="request">An IDinVerifyRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Verify(IDinVerifyRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("iDin", parameters, "verify");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The Login function creates a configured transaction with an IDinLoginRequest, that is ready to be executed.
        /// </summary>
        /// <param name="request">An IDinLoginRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Login(IDinLoginRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("iDin", parameters, "login");

            return configuredServiceTransaction;
        }
    }
}
