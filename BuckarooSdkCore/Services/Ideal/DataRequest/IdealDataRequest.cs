using BuckarooSdk.Data;

namespace BuckarooSdk.Services.Ideal.DataRequest
{
	public class IdealDataRequest
	{
		private ConfiguredDataRequest ConfiguredDataRequest { get; set; }

		internal IdealDataRequest(ConfiguredDataRequest configuredDateRequest)
		{
			this.ConfiguredDataRequest = configuredDateRequest;
		}

	}
}
