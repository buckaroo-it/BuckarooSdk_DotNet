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
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "Pay,ExtraInfo", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The authorize function creates a configured transaction with an PayPalAuthorizeRequest request,
        /// that is ready to be executed. An Authorize reserves the amount on the payer's account and must
        /// later be settled via Capture or released via CancelAuthorize.
        /// </summary>
        /// <param name="request">A PayPalAuthorizeRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Authorize(PayPalAuthorizeRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "authorize", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The capture function creates a configured transaction with an PayPalCaptureRequest request,
        /// that is ready to be executed. Captures the funds from a previously created authorization,
        /// identified by the basic OriginalTransactionKey field.
        /// </summary>
        /// <param name="request">A PayPalCaptureRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction Capture(PayPalCaptureRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", parameters, "capture", "1");

            return configuredServiceTransaction;
        }
        /// <summary>
        /// The cancelauthorize function creates a configured transaction with an PayPalCancelAuthorizeRequest request,
        /// that is ready to be executed. Voids a previously created authorization, identified by the
        /// basic OriginalTransactionKey field, releasing the reserved funds back to the payer.
        /// </summary>
        /// <param name="request">A PayPalCancelAuthorizeRequest</param>
        /// <returns></returns>
        public ConfiguredServiceTransaction CancelAuthorize(PayPalCancelAuthorizeRequest request)
        {
            var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
            configuredServiceTransaction.BaseTransaction.AddService("PayPal", null, "cancelauthorize", "1");

            return configuredServiceTransaction;
        }
    }
}
