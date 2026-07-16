using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BuckarooSdk;
using BuckarooSdk.Base;
using BuckarooSdk.Connection;
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
    /// Reproduces the production incident where a merchant received a <see cref="System.NullReferenceException"/>:
    /// a request blocked by AWS WAF came back as HTTP 429 with a non-JSON body and no Authorization header.
    /// The SDK previously (a) NullRef-ed inside the delegating handler while trying to read the missing
    /// signature header, and (b) swallowed the failure into a null response that the caller then dereferenced.
    /// A fake transport handler drives the full Connector -> delegating-handler -> response path with no network.
    /// </summary>
    public class ConnectorErrorHandlingTests
    {
        private sealed class StubTransportHandler : HttpMessageHandler
        {
            private readonly HttpResponseMessage _response;

            public StubTransportHandler(HttpResponseMessage response) => _response = response;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                => Task.FromResult(_response);
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
                    Invoice = "SDK_TEST_NON_200",
                })
                .Ideal()
                .Pay(new IdealPayRequest { Issuer = "INGBNL2A" });

            return (configured.BaseTransaction.AuthenticatedRequest.Request, configured.BaseTransaction.TransactionBase);
        }

        // A firewall/rate-limit response is HTML or plain text, never a signed Buckaroo JSON body.
        private static HttpResponseMessage BlockedResponse(HttpStatusCode statusCode)
            => new HttpResponseMessage(statusCode)
            {
                Content = new StringContent("<html><body>Request blocked by WAF</body></html>"),
            };

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
    }
}
