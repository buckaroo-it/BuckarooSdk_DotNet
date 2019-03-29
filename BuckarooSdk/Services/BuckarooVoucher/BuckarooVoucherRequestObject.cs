using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.BuckarooVoucher
{
	public class BuckarooVoucherRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredDataRequest ConfiguredDataRequest { get; }

		internal BuckarooVoucherRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		internal BuckarooVoucherRequestObject(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		/// <summary>
		/// The Pay function creates a configured transaction with an BuckarooVoucherPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A BuckarooVoucherPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(BuckarooVoucherPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("buckaroovoucher", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an BuckarooVoucherRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A BuckarooVoucherRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(BuckarooVoucherRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("buckaroovoucher", parameters, "Refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The GetBalance function creates a configured datarequest with an BuckarooVoucherGetBalanceRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A BuckarooVoucherGetBalanceRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest GetBalance(BuckarooVoucherGetBalanceRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService("buckaroovoucher", parameters, "GetBalance");

			return configuredServiceDataReqeust;
		}

		/// <summary>
		/// The CreateApplication function creates a configured datarequest with an BuckarooVoucherCreateApplicationRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A BuckarooVoucherCreateApplicationRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CreateApplication(BuckarooVoucherCreateApplicationRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService("buckaroovoucher", parameters, "CreateApplication");

			return configuredServiceDataReqeust;
		}


	}
}
