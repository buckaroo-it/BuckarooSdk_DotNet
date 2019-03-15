using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.AfterpayAcceptgiro
{
	public class AfterpayAcceptgiroRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal AfterpayAcceptgiroRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an AfterpayAcceptgiroPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayAcceptgiroPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(AfterpayAcceptgiroPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpayacceptgiro", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an AfterpayAcceptgiroRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayAcceptgiroRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(AfterpayAcceptgiroRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpayacceptgiro", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Authorize function creates a configured transaction with an AfterpayAcceptgiroAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayAcceptgiroAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Authorize(AfterpayAcceptgiroAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpayacceptgiro", parameters, "Authorize");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Capture function creates a configured transaction with an AfterpayAcceptgiroCaptureRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayAcceptgiroCaptureRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Capture(AfterpayAcceptgiroCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpayacceptgiro", parameters, "Capture");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The CancelAuthorize function creates a configured transaction with an AfterpayAcceptgiroCancelAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayAcceptgiroCancelAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CancelAuthorize(AfterpayAcceptgiroCancelAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpayacceptgiro", parameters, "CancelAuthorize");

			return configuredServiceTransaction;
		}
	}
}
