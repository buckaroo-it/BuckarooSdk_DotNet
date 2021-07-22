using BuckarooSdk.Data;

namespace BuckarooSdk.Services.Ideal.DataRequest
{
    /// <summary>
    /// iDEAL data request.
    /// </summary>
    public class IdealDataRequest
    {
        private ConfiguredDataRequest ConfiguredDataRequest { get; set; }

        internal IdealDataRequest(ConfiguredDataRequest configuredDateRequest)
        {
            ConfiguredDataRequest = configuredDateRequest;
        }
    }
}
