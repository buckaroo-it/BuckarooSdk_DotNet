using System.Text;
using BuckarooSdk.Connection;
using Xunit;

namespace BuckarooSdk.UnitTests.Connection
{
    /// <summary>
    /// The HMAC-SHA256 request/response/push signature is the SDK's security boundary and is fully
    /// deterministic, so it is exercised exhaustively here. A regression in this algorithm would make
    /// every live request fail authentication, so these tests guard the exact wire format.
    /// </summary>
    public class SignatureCalculationServiceTests
    {
        // Fixed inputs whose expected signature was computed independently (out-of-band) and pinned.
        // If the algorithm changes in any way, the known-answer test below breaks.
        private const string WebsiteKey = "WEBSITE123";
        private const string ApiKey = "SECRETAPIKEY";
        private const string HttpMethod = "POST";
        private const string Uri = "testcheckout.buckaroo.nl%2fjson%2ftransaction";
        private const string TimeStamp = "1500000000";
        private const string Nonce = "abcdef0123456789";
        private const string ExpectedSignature =
            "WEBSITE123:Hw0aw3Nd5g5Jg9Mv50h+vy+qS34hE+xAz4CfISejm5A=:abcdef0123456789:1500000000";

        private static readonly byte[] Body = Encoding.UTF8.GetBytes("{\"Currency\":\"EUR\"}");

        private static SignatureCalculationService NewService() => new SignatureCalculationService();

        [Fact]
        public void CalculateSignature_KnownInputs_ProducesPinnedSignature()
        {
            var signature = NewService().CalculateSignature(
                Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);

            Assert.Equal(ExpectedSignature, signature);
        }

        [Fact]
        public void CalculateSignature_FormatIsWebsiteKeyColonSignatureColonNonceColonTimestamp()
        {
            var signature = NewService().CalculateSignature(
                Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);

            var parts = signature.Split(':');
            Assert.Equal(4, parts.Length);
            Assert.Equal(WebsiteKey, parts[0]);
            Assert.NotEmpty(parts[1]); // base64 HMAC
            Assert.Equal(Nonce, parts[2]);
            Assert.Equal(TimeStamp, parts[3]);
        }

        [Fact]
        public void CalculateSignature_IsDeterministic_ForIdenticalInputs()
        {
            var a = NewService().CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var b = NewService().CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);

            Assert.Equal(a, b);
        }

        [Fact]
        public void CalculateSignature_EmptyBody_DiffersFromNonEmptyBody()
        {
            // With an empty body the MD5 content hash is skipped, so the raw signature string differs.
            var empty = NewService().CalculateSignature(
                System.Array.Empty<byte>(), HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var nonEmpty = NewService().CalculateSignature(
                Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);

            Assert.NotEqual(empty, nonEmpty);
        }

        [Fact]
        public void CalculateSignature_TamperedBody_ChangesSignature()
        {
            var original = NewService().CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var tampered = NewService().CalculateSignature(
                Encoding.UTF8.GetBytes("{\"Currency\":\"USD\"}"), HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);

            Assert.NotEqual(original, tampered);
        }

        [Theory]
        [InlineData("OTHERKEY", ApiKey, HttpMethod, Uri, TimeStamp, Nonce)]
        [InlineData(WebsiteKey, "OTHERSECRET", HttpMethod, Uri, TimeStamp, Nonce)]
        [InlineData(WebsiteKey, ApiKey, "GET", Uri, TimeStamp, Nonce)]
        [InlineData(WebsiteKey, ApiKey, HttpMethod, "other.host%2fpath", TimeStamp, Nonce)]
        [InlineData(WebsiteKey, ApiKey, HttpMethod, Uri, "1600000000", Nonce)]
        [InlineData(WebsiteKey, ApiKey, HttpMethod, Uri, TimeStamp, "differentnonce00")]
        public void CalculateSignature_IsSensitiveToEveryInput(
            string websiteKey, string apiKey, string method, string uri, string timeStamp, string nonce)
        {
            var baseline = NewService().CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var altered = NewService().CalculateSignature(Body, method, timeStamp, nonce, uri, websiteKey, apiKey);

            Assert.NotEqual(baseline, altered);
        }

        [Fact]
        public void VerifySignature_RoundTripsWithCalculateSignature()
        {
            var service = NewService();
            var signature = service.CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var authorizationHeader = $"hmac {signature}";

            var verified = service.VerifySignature(Body, HttpMethod, Uri, ApiKey, authorizationHeader);

            Assert.True(verified);
        }

        [Fact]
        public void VerifySignature_ReturnsFalse_WhenBodyIsTampered()
        {
            var service = NewService();
            var signature = service.CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var authorizationHeader = $"hmac {signature}";

            var verified = service.VerifySignature(
                Encoding.UTF8.GetBytes("{\"Currency\":\"USD\"}"), HttpMethod, Uri, ApiKey, authorizationHeader);

            Assert.False(verified);
        }

        [Fact]
        public void VerifySignature_ReturnsFalse_WhenApiKeyIsWrong()
        {
            var service = NewService();
            var signature = service.CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var authorizationHeader = $"hmac {signature}";

            var verified = service.VerifySignature(Body, HttpMethod, Uri, "WRONGSECRET", authorizationHeader);

            Assert.False(verified);
        }

        [Fact]
        public void VerifySignature_ReturnsFalse_WhenRequestUriDiffers()
        {
            var service = NewService();
            var signature = service.CalculateSignature(Body, HttpMethod, TimeStamp, Nonce, Uri, WebsiteKey, ApiKey);
            var authorizationHeader = $"hmac {signature}";

            var verified = service.VerifySignature(Body, HttpMethod, "other.host%2fpath", ApiKey, authorizationHeader);

            Assert.False(verified);
        }
    }
}
