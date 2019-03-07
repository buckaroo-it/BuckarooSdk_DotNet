using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Ideal.DataRequest
{
	public class IdealDataRequest
	{
		private ConfiguredTransaction ConfiguredDataRequest { get; set; }

		internal IdealDataRequest(ConfiguredTransaction configuredDateRequest)
		{
			this.ConfiguredDataRequest = configuredDateRequest;
		}

	}
}
