using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal AfterpayRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The CancelAuthorize function creates a configured transaction with an AfterpayCancelAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayCancelAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CancelAuthorize(AfterpayCancelAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpay", parameters, "CancelAuthorize");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an AfterpayPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(AfterpayPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpay", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an AfterpayRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(AfterpayRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpay", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Authorize function creates a configured transaction with an AfterpayAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Authorize(AfterpayAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpay", parameters, "Authorize");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Capture function creates a configured transaction with an AfterpayCaptureRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A AfterpayCaptureRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Capture(AfterpayCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("afterpay", parameters, "Capture");

			return configuredServiceTransaction;
		}
	}
}
