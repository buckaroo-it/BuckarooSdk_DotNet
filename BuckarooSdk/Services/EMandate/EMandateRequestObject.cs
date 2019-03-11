using BuckarooSdk.Transaction;
using BuckarooSdk.Data;

namespace BuckarooSdk.Services.EMandate
{
	public class EMandateRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }
		private ConfiguredDataRequest ConfiguredDataRequest { get; }

		internal EMandateRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		internal EMandateRequestObject(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		/// <summary>
		/// The CreateMandate function creates a configured datarequest with an EMandateCreateMandateRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A EMandateCreateMandateRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CreateMandate(EMandateCreateMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService("emandate", parameters, "CreateMandate");

			return configuredServiceDataReqeust;
		}

		/// <summary>
		/// The GetIssuerList function creates a configured datarequest with an EMandateGetIssuerListRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A EMandateGetIssuerListRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest GetIssuerList(EMandateGetIssuerListRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService("emandate", parameters, "GetIssuerList");

			return configuredServiceDataReqeust;
		}

		/// <summary>
		/// The GetStatus function creates a configured datarequest with an EMandateGetStatusRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A EMandateGetStatusRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest GetStatus(EMandateGetStatusRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService("emandate", parameters, "GetStatus");

			return configuredServiceDataReqeust;
		}

		/// <summary>
		/// The ModifyMandate function creates a configured datarequest with an EMandateModifyMandateRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A EMandateModifyMandateRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest ModifyMandate(EMandateModifyMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataReqeust = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataReqeust.BaseData.AddService("emandate", parameters, "ModifyMandate");

			return configuredServiceDataReqeust;
		}


	}
}
