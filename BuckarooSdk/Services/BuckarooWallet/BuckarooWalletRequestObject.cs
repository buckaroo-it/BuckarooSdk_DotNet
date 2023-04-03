using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.BuckarooWallet
{
    public class BuckarooWalletRequestObject
    {
        /// <summary>
        /// The configured transaction
        /// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; }

        /// <summary>
        /// The configured dataRequest
        /// </summary>
        private ConfiguredDataRequest ConfiguredDataRequest { get; }

        internal BuckarooWalletRequestObject(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        internal BuckarooWalletRequestObject(ConfiguredDataRequest configuredDataRequest)
        {
            this.ConfiguredDataRequest = configuredDataRequest;
        }

        /// <summary>
        /// The Pay function creates a configured transaction with an BuckarooWalletPayRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BuckarooWalletPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(BuckarooWalletPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("buckaroowallet", parameters, "Pay");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The Refund function creates a configured transaction with an BuckarooWalletRefundRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BuckarooWalletRefundRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Refund(BuckarooWalletRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("buckaroowallet", parameters, "Refund");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The GetBalance function creates a configured dataRequest with an BuckarooWalletGetBalanceRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BuckarooWalletGetBalanceRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest GetBalance(BuckarooWalletGetBalanceRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("buckaroowallet", parameters, "GetBalance");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// The CreateApplication function creates a configured dataRequest with an BuckarooWalletCreateApplicationRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BuckarooWalletCreateApplicationRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest CreateApplication(BuckarooWalletCreateApplicationRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("buckaroowallet", parameters, "CreateApplication");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// The Deposit function creates a configured dataRequest with an BuckarooWalletDepositRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BuckarooWalletDepositRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest Deposit(BuckarooWalletDepositRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("buckaroowallet", parameters, "Deposit");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// The Update function creates a configured dataRequest with an BuckarooWalletUpdateRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BuckarooWalletUpdateRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest Update(BuckarooWalletUpdateRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("buckaroowallet", parameters, "Update");

            return configuredServiceDataRequest;
        }
    }
}
