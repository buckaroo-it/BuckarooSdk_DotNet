using System;
using BuckarooSdk;
using BuckarooSdk.Base;
using BuckarooSdk.Connection;
using BuckarooSdk.Logging;
using BuckarooSdk.UnitTests.TestSupport;
using Xunit;

namespace BuckarooSdk.UnitTests
{
    /// <summary>
    /// Exercises the public <see cref="SdkClient"/> entry point: request creation, logger selection,
    /// and the push/signature helper factories. None of these touch the network.
    /// </summary>
    public class SdkClientTests
    {
        [Fact]
        public void CreateRequest_ReturnsRequest()
        {
            Assert.NotNull(new SdkClient().CreateRequest());
        }

        [Fact]
        public void CreateRequest_WithExplicitLogger_ReturnsRequest()
        {
            Assert.NotNull(new SdkClient().CreateRequest(new StandardLogger()));
            Assert.NotNull(new SdkClient().CreateRequest(new ExtensiveLogger()));
        }

        [Fact]
        public void Constructor_NullLoggerFactory_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new SdkClient((Func<ILogger>)null));
        }

        [Fact]
        public void Constructor_CustomLoggerFactory_IsUsedForCreatedRequests()
        {
            var client = new SdkClient(() => new ExtensiveLogger());

            // Assert the produced request actually carries the logger the factory makes — otherwise this
            // would pass even if the factory were ignored and the default StandardLogger used.
            Assert.IsType<ExtensiveLogger>(client.CreateRequest().BuckarooSdkLogger);
        }

        [Fact]
        public void GetPushHandler_ReturnsHandler()
        {
            Assert.NotNull(new SdkClient().GetPushHandler(TestCredentials.ApiKey));
        }

        [Fact]
        public void GetPushHandler_IsCachedPerClient()
        {
            var client = new SdkClient();

            var first = client.GetPushHandler(TestCredentials.ApiKey);
            var second = client.GetPushHandler(TestCredentials.ApiKey);

            Assert.Same(first, second);
        }

        [Fact]
        public void GetPushHandler_IgnoresApiKeyAfterFirstCall()
        {
            // Characterizes a real hazard: the handler is cached on first use and the apiKey argument is
            // ignored thereafter, so a later call with a *different* key silently returns the handler bound
            // to the FIRST key. Pinning this makes any change to the contract a deliberate, visible one.
            var client = new SdkClient();

            var first = client.GetPushHandler(TestCredentials.ApiKey);
            var second = client.GetPushHandler("A_COMPLETELY_DIFFERENT_KEY");

            Assert.Same(first, second);
        }

        [Fact]
        public void GetSignatureCalculationService_ReturnsService()
        {
            Assert.NotNull(new SdkClient().GetSignatureCalculationService());
        }
    }
}
