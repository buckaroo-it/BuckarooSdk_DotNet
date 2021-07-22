using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuckarooSdk.Tests.Constants;


namespace BuckarooSdk.Tests.Services.Subscriptions
{
    [TestClass]
    public class SubscriptionRequestTests
    {
        private SdkClient buckarooClient;

        [TestInitialize]
        public void Setup()
        {
            buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void CreateSubscriptionTest()
        {
            //var request = this._buckarooClient.CreateRequest()
            //.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
            //.Subscriptions()
        }
    }
}
