using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.CustomGiftcard
{
	public class CustomGiftcardRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		/// <summary>
		/// The configured datarequest
		/// </summary>
		private ConfiguredDataRequest ConfiguredDataRequest { get; }

		internal Constants.Services.ServiceNames ServiceName { get; set; }

		internal CustomGiftcardRequestObject(ConfiguredTransaction configuredTransaction, Constants.Services.ServiceNames serviceName)
		{
			this.ConfiguredTransaction = configuredTransaction;
			this.ServiceName = serviceName;
		}

		internal CustomGiftcardRequestObject(ConfiguredDataRequest configuredDataRequest, Constants.Services.ServiceNames serviceName)
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
		/// The CardInfo function creates a configured datarequest with an CustomGiftcardCardInfoRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CustomGiftcardCardInfoRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CardInfo(CustomGiftcardCardInfoRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService(this.ServiceName.ToString(), parameters, "CardInfo");

			return configuredServiceDataReqeust;
		}
	}
}
