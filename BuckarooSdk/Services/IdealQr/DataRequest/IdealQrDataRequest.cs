using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.IdealQr.DataRequest
{
	public class IdealQrDataRequest
	{
		private ConfiguredTransaction ConfiguredDataRequest { get; set; }

		internal IdealQrDataRequest(ConfiguredTransaction configuredDateRequest)
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
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseTransaction);
			configuredServiceDataRequest.BaseData.AddService("IdealQr", parameters, "Generate");

			return configuredServiceDataRequest;
		}
	}
}
