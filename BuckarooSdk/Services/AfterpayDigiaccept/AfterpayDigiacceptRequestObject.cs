using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.AfterpayDigiaccept
{
	public class AfterpayDigiacceptRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal AfterpayDigiacceptRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an AfterpayDigiacceptPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayDigiacceptPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(AfterpayDigiacceptPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpaydigiaccept", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an AfterpayDigiacceptRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayDigiacceptRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(AfterpayDigiacceptRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpaydigiaccept", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Authorize function creates a configured transaction with an AfterpayDigiacceptAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayDigiacceptAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Authorize(AfterpayDigiacceptAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpaydigiaccept", parameters, "Authorize");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Capture function creates a configured transaction with an AfterpayDigiacceptCaptureRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayDigiacceptCaptureRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Capture(AfterpayDigiacceptCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpaydigiaccept", parameters, "Capture");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The CancelAuthorize function creates a configured transaction with an AfterpayDigiacceptCancelAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayDigiacceptCancelAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CancelAuthorize(AfterpayDigiacceptCancelAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpaydigiaccept", parameters, "CancelAuthorize");

			return configuredServiceTransaction;
		}
	}
}
