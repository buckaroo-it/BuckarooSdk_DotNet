using BuckarooSdk.Data;

namespace BuckarooSdk.Services.IdealQr.DataRequest
{
	public class IdealQrDataRequest
	{
		private ConfiguredDataRequest ConfiguredDataRequest { get; set; }

		internal IdealQrDataRequest(ConfiguredDataRequest configuredDateRequest)
		{
			this.ConfiguredDataRequest = configuredDateRequest;
		}

		/// <summary>
		/// The Generate function creates a configured datarequest with an IdealQrGenerateRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealQrGenerateRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest Generate(IdealQrGenerateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataRequest.BaseData.AddService("IdealQr", parameters, "Generate");

			return configuredServiceDataRequest;
		}
	}
}
