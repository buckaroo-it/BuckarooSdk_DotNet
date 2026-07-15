using System.Net;
using System.Security.Authentication;
using System.Runtime.Serialization;
using System.Text;
using BuckarooSdk;
using BuckarooSdk.Base;
using BuckarooSdk.Connection;
using BuckarooSdk.DataTypes.Push;
using BuckarooSdk.Services.Ideal.Push;
using BuckarooSdk.UnitTests.TestSupport;
using Xunit;

namespace BuckarooSdk.UnitTests.Base
{
    /// <summary>
    /// Verifies push (webhook) handling end-to-end without any network: a push body is signed with the
    /// SDK's own <see cref="SignatureCalculationService"/> exactly as Buckaroo would, then handed to the
    /// <c>PushHandler</c> obtained from the public <see cref="SdkClient"/> entry point.
    /// </summary>
    public class PushHandlerTests
    {
        private const string PushUri = "https://myshop.example.com/buckaroo/push";

        private static string SignedAuthorizationHeader(byte[] body)
        {
            var encodedUri = WebUtility.UrlEncode(PushUri).ToLower();
            var signature = new SignatureCalculationService().CalculateSignature(
                body,
                System.Net.Http.HttpMethod.Post.ToString(),
                "1500000000",
                "nonce0123456789",
                encodedUri,
                TestCredentials.WebsiteKey,
                TestCredentials.ApiKey);

            return $"hmac {signature}";
        }

        private static PushHandler NewPushHandler()
            => new SdkClient().GetPushHandler(TestCredentials.ApiKey);

        [Fact]
        public void DeserializePush_ValidTransactionPush_ParsesTopLevelFields()
        {
            var body = TestData.ReadBytes("Pushes", "ideal-transaction-push.json");
            var authorizationHeader = SignedAuthorizationHeader(body);

            var push = NewPushHandler().DeserializePush(body, PushUri, authorizationHeader);

            var transactionPush = Assert.IsType<TransactionPush>(push);
            Assert.Equal("F948CAA0C8FC4371892126BB03AB997C", transactionPush.Key);
            Assert.Equal("NL1802813331", transactionPush.Invoice);
            Assert.Equal("ideal", transactionPush.ServiceCode);
            Assert.Equal(BuckarooSdk.Constants.Status.Success, transactionPush.Status.Code.Code);
            Assert.True(transactionPush.IsTest);
            Assert.Equal(71.84m, transactionPush.AmountDebit);
        }

        [Fact]
        public void DeserializePush_ValidTransactionPush_ResolvesTypedActionResponse()
        {
            var body = TestData.ReadBytes("Pushes", "ideal-transaction-push.json");
            var push = NewPushHandler().DeserializePush(body, PushUri, SignedAuthorizationHeader(body));

            var ideal = push.GetActionResponse<IdealPayPush>();

            Assert.NotNull(ideal);
            Assert.Equal("NL89INGB0002056758", ideal.ConsumerIban);
            Assert.Equal("INGBNL2A", ideal.ConsumerBic);
            Assert.Equal("ING Bank", ideal.ConsumerIssuer);
            Assert.Equal("J. de Tester", ideal.ConsumerName);
            Assert.Equal("1150000854689906", ideal.Transactionid);
        }

        [Fact]
        public void DeserializePush_ExposesSelectedServiceNames()
        {
            var body = TestData.ReadBytes("Pushes", "ideal-transaction-push.json");
            var push = NewPushHandler().DeserializePush(body, PushUri, SignedAuthorizationHeader(body));

            var services = push.GetServices();

            Assert.Contains(BuckarooSdk.Constants.Services.ServiceNames.Ideal, services);
        }

        [Fact]
        public void DeserializePush_InvalidSignature_ThrowsAuthenticationException()
        {
            var body = TestData.ReadBytes("Pushes", "ideal-transaction-push.json");
            // A validly-formatted header signed for a different body will not verify against this body.
            var wrongHeader = SignedAuthorizationHeader(Encoding.UTF8.GetBytes("{\"Transaction\":{}}"));

            Assert.Throws<AuthenticationException>(
                () => NewPushHandler().DeserializePush(body, PushUri, wrongHeader));
        }

        [Fact]
        public void DeserializePush_TamperedBody_ThrowsAuthenticationException()
        {
            var body = TestData.ReadBytes("Pushes", "ideal-transaction-push.json");
            var authorizationHeader = SignedAuthorizationHeader(body);

            // Flip one byte directly so the tamper is guaranteed regardless of fixture content
            // (a content-coupled string replace could silently become a no-op after a fixture edit).
            var tamperedBody = (byte[])body.Clone();
            tamperedBody[tamperedBody.Length / 2] ^= 0x01;

            Assert.Throws<AuthenticationException>(
                () => NewPushHandler().DeserializePush(tamperedBody, PushUri, authorizationHeader));
        }

        [Fact]
        public void DeserializePush_ValidDataRequestPush_ReturnsDataRequest()
        {
            var body = TestData.ReadBytes("Pushes", "emandate-datarequest-push.json");

            var push = NewPushHandler().DeserializePush(body, PushUri, SignedAuthorizationHeader(body));

            var dataRequest = Assert.IsType<DataRequest>(push);
            Assert.Equal("7B9E1C2D3F4A4B5C8D9E0F1A2B3C4D5E", dataRequest.Key);
            Assert.Equal("emandate", dataRequest.ServiceCode);
            Assert.Equal(BuckarooSdk.Constants.Status.Success, dataRequest.Status.Code.Code);
        }

        [Fact]
        public void DeserializePush_ExtractsCustomParameters()
        {
            var body = TestData.ReadBytes("Pushes", "ideal-push-with-custom-parameters.json");

            var push = NewPushHandler().DeserializePush(body, PushUri, SignedAuthorizationHeader(body));

            var transactionPush = Assert.IsType<TransactionPush>(push);
            Assert.NotNull(transactionPush.CustomParameters);
            Assert.Collection(transactionPush.CustomParameters.List,
                p => { Assert.Equal("OrderId", p.Name); Assert.Equal("ORDER-4242", p.Value); },
                p => { Assert.Equal("ShopReference", p.Name); Assert.Equal("SHOP-7", p.Value); });
        }

        [Fact]
        public void DeserializePush_UnknownPushType_ThrowsSerializationException()
        {
            var body = Encoding.UTF8.GetBytes("{\"Something\":{\"Key\":\"X\"}}");
            var authorizationHeader = SignedAuthorizationHeader(body);

            Assert.Throws<SerializationException>(
                () => NewPushHandler().DeserializePush(body, PushUri, authorizationHeader));
        }
    }
}
