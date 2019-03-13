using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuckarooSdk.Tests.Constants;


namespace BuckarooSdk.Tests.Services.Subscriptions
{
	[TestClass]
	public class SubscriptionRequestTests
	{
		private SdkClient BuckarooClient { get; set; }

		[TestInitialize]
		public void Setup()
		{
			this.BuckarooClient = new SdkClient(TestSettings.Logger);
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