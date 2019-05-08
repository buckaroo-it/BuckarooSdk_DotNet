using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.PayPal
{
    public class PayPalTransaction
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; set; }

        internal PayPalTransaction(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

        /// <summary>
        /// The pay function creates a configured transaction with an PayPalPayRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A PayPalPayRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Pay(PayPalPayRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);            
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "pay", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The refund function creates a configured transaction with an PayPalRefundRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A PayPalRefundRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Refund(PayPalRefundRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", null, "refund", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The payrecurrent function creates a configured transaction with an PayPalPayRecurrentRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A PayPalPayRecurrentRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayRecurrent(PayPalPayRecurrentRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "payrecurrent", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The payremainder function creates a configured transaction with an PayPalPayRemainderRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A PayPalPayRemainderRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction PayRemainder(PayPalPayRemainderRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "payremainder", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The extrainfo function creates a configured transaction with an PayPalExtraInfoRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A PayPalExtraInfoRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction ExtraInfo(PayPalExtraInfoRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "ExtraInfo", "1");

            return configuredServiceTransaction;
        }
    }
}
