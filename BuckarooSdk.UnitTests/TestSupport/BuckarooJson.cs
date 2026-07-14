using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace BuckarooSdk.UnitTests.TestSupport
{
    /// <summary>
    /// Serializes request bodies with the exact same settings the SDK's <c>Connector</c> uses when
    /// it posts to the Buckaroo gateway (camelCase property names, indented). Tests assert on the
    /// produced JSON so they verify precisely what would go over the wire — without any network call.
    /// </summary>
    public static class BuckarooJson
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        public static string Serialize(object value) => JsonConvert.SerializeObject(value, Settings);

        public static JObject SerializeToObject(object value) => JObject.Parse(Serialize(value));
    }
}
