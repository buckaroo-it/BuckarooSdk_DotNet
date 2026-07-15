using System.Linq;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.UnitTests.TestSupport;
using Newtonsoft.Json;
using Xunit;

namespace BuckarooSdk.UnitTests.Serialization
{
    /// <summary>
    /// Deserializes a recorded gateway response into the <see cref="RequestResponse"/> that every
    /// <c>Execute()</c> returns, using the same call the SDK's <c>Connector</c> makes
    /// (<c>JsonConvert.DeserializeObject&lt;RequestResponse&gt;</c> with default settings). This covers the
    /// response side of the wire — status parsing, service lookup, and the reflection-based
    /// <c>GetActionResponse&lt;T&gt;</c> mapping — without any network call.
    /// </summary>
    public class ResponseDeserializationTests
    {
        private static RequestResponse LoadIdealPayResponse()
        {
            var json = TestData.ReadText("Responses", "ideal-pay-response.json");
            return JsonConvert.DeserializeObject<RequestResponse>(json);
        }

        [Fact]
        public void Deserialize_ParsesTopLevelFieldsAndStatus()
        {
            var response = LoadIdealPayResponse();

            Assert.Equal("A9CF3A004C0144A2B1709EFAE7841388", response.Key);
            Assert.Equal("NL1802813331", response.Invoice);
            Assert.Equal("ideal", response.ServiceCode);
            Assert.Equal(BuckarooSdk.Constants.Status.Success, response.Status.Code.Code);
            Assert.Equal(12.34m, response.AmountDebit);
        }

        [Fact]
        public void Deserialize_ExposesSelectedServiceNames()
        {
            var response = LoadIdealPayResponse();

            Assert.Contains(BuckarooSdk.Constants.Services.ServiceNames.Ideal, response.GetServices());
        }

        [Fact]
        public void GetActionResponse_MapsServiceParametersOntoTypedResponse()
        {
            var response = LoadIdealPayResponse();

            var ideal = response.GetActionResponse<IdealPayResponse>();

            Assert.NotNull(ideal);
            Assert.Equal("1150000854689906", ideal.TransactionId);
            Assert.Equal("ING Bank", ideal.ConsumerIssuer);
        }

        [Fact]
        public void GetActionResponse_ReturnsNull_WhenServiceAbsent()
        {
            var response = LoadIdealPayResponse();

            // No PayPal service is present in the response, so the typed lookup returns null.
            var payPal = response.GetActionResponse<BuckarooSdk.Services.PayPal.PayPalPayResponse>();

            Assert.Null(payPal);
        }
    }
}
