using BuckarooSdk.Data;

namespace BuckarooSdk.Services.EMandate
{
    public class EMandateRequestObject
    {
        /// <summary>
        /// The configured transaction
        /// </summary>
		private ConfiguredDataRequest ConfiguredDataRequest { get; }

        internal EMandateRequestObject()
        {
        }

        internal EMandateRequestObject(ConfiguredDataRequest configuredDataRequest)
        {
            this.ConfiguredDataRequest = configuredDataRequest;
        }

        /// <summary>
        /// The CreateMandate function creates a configured dataRequest with an EMandateCreateMandateRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EMandateCreateMandateRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest CreateMandate(EMandateCreateMandateRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("emandate", parameters, "CreateMandate");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// The GetIssuerList function creates a configured dataRequest with an EMandateGetIssuerListRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EMandateGetIssuerListRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest GetIssuerList(EMandateGetIssuerListRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("emandate", parameters, "GetIssuerList");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// The GetStatus function creates a configured dataRequest with an EMandateGetStatusRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EMandateGetStatusRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest GetStatus(EMandateGetStatusRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("emandate", parameters, "GetStatus");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// The ModifyMandate function creates a configured dataRequest with an EMandateModifyMandateRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A EMandateModifyMandateRequest</param>
        /// <returns></returns>
        public ConfiguredServiceDataRequest ModifyMandate(EMandateModifyMandateRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("emandate", parameters, "ModifyMandate");

            return configuredServiceDataRequest;
        }

        /// <summary>
        /// </summary>
        public ConfiguredServiceDataRequest CancelMandate(EMandateCancelMandateRequest request)
        {
            var parameters = ServiceHelper.CreateServiceParameters(request);
            var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("emandate", parameters, "CancelMandate");

            return configuredServiceDataRequest;
        }
    }
}
