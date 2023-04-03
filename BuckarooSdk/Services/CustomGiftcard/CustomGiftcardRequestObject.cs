using BuckarooSdk.Data;
using BuckarooSdk.Transaction;
using ServiceNames = BuckarooSdk.Constants.Services.ServiceNames;

namespace BuckarooSdk.Services.CustomGiftcard
{
    public class CustomGiftcardRequestObject
    {
        /// <summary>
        /// The configured transaction
        /// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; }

        /// <summary>
        /// The configured dataRequest
        /// </summary>
        private ConfiguredDataRequest ConfiguredDataRequest { get; }

        internal ServiceNames ServiceName { get; set; }

        internal CustomGiftcardRequestObject(ConfiguredTransaction configuredTransaction, ServiceNames serviceName)
        {
            this.ConfiguredTransaction = configuredTransaction;
            this.ServiceName = serviceName;
        }

        internal CustomGiftcardRequestObject(ConfiguredDataRequest configuredDataRequest, ServiceNames serviceName)
        {
            this.ConfiguredDataRequest = configuredDataRequest;
            this.ServiceName = serviceName;
        }

        /// <summary>
        /// The Pay function creates a configured transaction with an CustomGiftcardPayRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A CustomGiftcardPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(CustomGiftcardPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "Pay");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The Refund function creates a configured transaction with an CustomGiftcardRefundRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A CustomGiftcardRefundRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Refund(CustomGiftcardRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "Refund");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The PayRemainder function creates a configured transaction with an CustomGiftcardPayRemainderRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A CustomGiftcardPayRemainderRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayRemainder(CustomGiftcardPayRemainderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "PayRemainder");

            return configuredServiceTransaction;
        }

        /// <summary>
        /// The CardInfo function creates a configured dataRequest with an CustomGiftcardCardInfoRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A CustomGiftcardCardInfoRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest CardInfo(CustomGiftcardCardInfoRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService(this.ServiceName.ToString(), parameters, "CardInfo");

            return configuredServiceDataRequest;
        }
    }
}
