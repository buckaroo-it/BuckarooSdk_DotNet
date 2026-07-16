using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BuckarooSdk;
using BuckarooSdk.Base;
using BuckarooSdk.Connection;
using BuckarooSdk.Constants;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.UnitTests.TestSupport;
using Xunit;

namespace BuckarooSdk.UnitTests.Connection
{
    /// <summary>
    /// Drives the full HTTP client path (<c>Connector.SendRequest</c> -> <c>BuckarooDelegatingHandler</c> ->
    /// response) offline via an injected <see cref="HttpMessageHandler"/>. The success cases sign the
    /// response body with the SDK's own <see cref="SignatureCalculationService"/> exactly as the gateway
    /// would, so the delegating handler's signature check runs for real. The failure cases pin the behaviour
    /// behind the production incident where a WAF-blocked request (HTTP 429, no Authorization header,
    /// non-JSON body) was swallowed into a null response and then dereferenced into a NullReferenceException.
    /// </summary>
    public class ConnectorTests
    {
        private const string TestHost = "testcheckout.buckaroo.nl";
        private const string TransactionEndpoint = "/json/transaction";

        private sealed class StubTransportHandler : HttpMessageHandler
        {
            private readonly HttpResponseMessage _response;

            public StubTransportHandler(HttpResponseMessage response) => _response = response;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => Task.FromResult(_response);
        }

        private sealed class ThrowingTransportHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => throw new HttpRequestException("The connection was reset by the peer.");
        }

        private static (Request request, IRequestBase data) BuildIdealTransaction()
        {
            var configured = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, isLive: false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 1.00m,
                    Invoice = "SDK_TEST_HTTP",
                })
                .Ideal()
                .Pay(new IdealPayRequest { Issuer = "INGBNL2A" });

            return (configured.BaseTransaction.AuthenticatedRequest.Request, configured.BaseTransaction.TransactionBase);
        }

        // The delegating handler validates the response signature against the request method and URI. This
        // mirrors BuckarooDelegatingHandler.SendAsync for an isLive:false transaction POST.
        private static string ExpectedRequestUri()
            => WebUtility.UrlEncode(TestHost + TransactionEndpoint).ToLower();

        private static HttpResponseMessage SignedResponse(HttpStatusCode statusCode, string body)
        {
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            var signature = new SignatureCalculationService().CalculateSignature(
                Encoding.UTF8.GetBytes(body), "POST", "1500000000", "abcdef0123456789",
                ExpectedRequestUri(), TestCredentials.WebsiteKey, TestCredentials.ApiKey);
            response.Headers.TryAddWithoutValidation("Authorization", $"hmac {signature}");

            return response;
        }

        // A firewall/rate-limit response is HTML or plain text, never a signed Buckaroo JSON body.
        private static HttpResponseMessage BlockedResponse(HttpStatusCode statusCode)
            => new HttpResponseMessage(statusCode)
            {
                Content = new StringContent("<html><body>Request blocked by WAF</body></html>"),
            };

        [Fact]
        public async Task SignedSuccessResponse_IsValidatedDeserializedAndReturned()
        {
            var (request, data) = BuildIdealTransaction();
            var body = TestData.ReadText("Responses", "ideal-pay-response.json");
            var handler = new StubTransportHandler(SignedResponse(HttpStatusCode.OK, body));

            var response = await Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler);

            Assert.NotNull(response);
            Assert.Equal("A9CF3A004C0144A2B1709EFAE7841388", response.Key);
            Assert.Equal("NL1802813331", response.Invoice);
            Assert.Equal(Status.Success, response.Status.Code.Code);
            Assert.Equal(12.34m, response.AmountDebit);

            // The full pipeline yields the same typed action mapping as deserializing the fixture directly.
            var ideal = response.GetActionResponse<IdealPayResponse>();
            Assert.Equal("1150000854689906", ideal.TransactionId);
        }

        [Fact]
        public async Task SuccessResponseWithInvalidSignature_ThrowsBuckarooException()
        {
            // A 200 whose HMAC does not verify must be rejected (the security boundary) and surfaced, not
            // returned as if it were genuine.
            var (request, data) = BuildIdealTransaction();
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"Key\":\"TX\"}", Encoding.UTF8, "application/json"),
            };
            response.Headers.TryAddWithoutValidation("Authorization", "hmac WEBSITE:not-the-real-signature:nonce:1500000000");
            var handler = new StubTransportHandler(response);

            await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));
        }

        [Fact]
        public async Task SuccessResponseWithoutSignature_FailsClosed_WithoutNullReference()
        {
            // A 200 with no Authorization header must fail signature validation cleanly. Previously this
            // dereferenced a null header collection and threw NullReferenceException from inside the handler.
            var (request, data) = BuildIdealTransaction();
            var unsignedOk = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") };
            var handler = new StubTransportHandler(unsignedOk);

            // ThrowsAsync asserts the exact type, so a NullReferenceException (the old behaviour) fails the test.
            await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));
        }

        [Fact]
        public async Task SignedButMalformedBody_ThrowsBuckarooException_InsteadOfReturningNull()
        {
            // Reaches the deserialization catch: the response passes signature validation but the body is not
            // valid JSON. This also guards the widened catch (JsonReaderException, not only JsonSerializationException).
            var (request, data) = BuildIdealTransaction();
            var body = "<html>not json</html>";
            var handler = new StubTransportHandler(SignedResponse(HttpStatusCode.OK, body));

            var exception = await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));

            Assert.Equal(HttpStatusCode.OK, exception.StatusCode);
            Assert.Contains(body, exception.ResponseBody);
        }

        [Fact]
        public async Task SignedEmptyResponse_ThrowsBuckarooException_InsteadOfReturningNull()
        {
            // A signed body that deserializes to null (literal JSON null / empty payload) must not be returned
            // as a null response for the caller to dereference.
            var (request, data) = BuildIdealTransaction();
            var handler = new StubTransportHandler(SignedResponse(HttpStatusCode.OK, "null"));

            var exception = await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));

            Assert.Equal(HttpStatusCode.OK, exception.StatusCode);
        }

        [Fact]
        public async Task TooManyRequests_ThrowsBuckarooExceptionWithStatusCode_InsteadOfReturningNull()
        {
            var (request, data) = BuildIdealTransaction();
            var handler = new StubTransportHandler(BlockedResponse(HttpStatusCode.TooManyRequests));

            var exception = await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));

            Assert.Equal(HttpStatusCode.TooManyRequests, exception.StatusCode);
            Assert.Contains("429", exception.Message);
        }

        [Fact]
        public async Task Forbidden_PreservesResponseBodyForDiagnostics()
        {
            var (request, data) = BuildIdealTransaction();
            var handler = new StubTransportHandler(BlockedResponse(HttpStatusCode.Forbidden));

            var exception = await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));

            Assert.Equal(HttpStatusCode.Forbidden, exception.StatusCode);
            Assert.Contains("Request blocked by WAF", exception.ResponseBody);
        }

        [Fact]
        public async Task TransportFailure_ThrowsBuckarooException_InsteadOfReturningNull()
        {
            // A connection reset / timeout never produces an HTTP response, so there is no status code, but it
            // must still surface as a catchable BuckarooException rather than a null the caller dereferences.
            var (request, data) = BuildIdealTransaction();
            var handler = new ThrowingTransportHandler();

            var exception = await Assert.ThrowsAsync<BuckarooException>(() =>
                Connector.SendRequest<IRequestBase, RequestResponse>(request, data, HttpRequestType.Post, handler));

            Assert.Null(exception.StatusCode);
            Assert.IsType<HttpRequestException>(exception.InnerException);
        }
    }
}
