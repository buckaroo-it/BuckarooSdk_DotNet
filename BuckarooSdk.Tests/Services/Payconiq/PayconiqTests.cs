using BuckarooSdk.Services.Payconiq.TransactionRequest;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;


namespace BuckarooSdk.Tests.Services.Payconiq
{
	[TestClass]
	public class PayconiqTests
	{
		public SdkClient BuckarooClient { get; private set; }

		[TestInitialize]
		public void Setup()
		{
			this.BuckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void PayTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, TestSettings.Test, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "PAYCONIQ_PAY_SDK_UNITTEST",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					
				})
				.Payconiq()
				.Pay(new PayconiqPayRequest());

			var response = request.Execute();

			Process.Start(response.RequiredAction.RedirectURL);

			this.TestContext.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		
		[TestMethod]
		public void RefundTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))

				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					AmountCredit = 0.02m,
					Currency = "EUR",
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}", 
					OriginalTransactionKey = "DDE3795437444D2AB1B803EA829C89E5", //set before each refund test
					Description = "IDEAL_REFUND_SDK_UNITTEST",
				})
				.Payconiq()

				.Refund(new PayconiqRefundRequest());

			var response = request.Execute();

			var logging = response.BuckarooSdkLogger.GetFullLog();
			Console.WriteLine(logging);
		}

		[TestMethod]
		[Ignore]
		public void PayRemainderTest()
		{

		}
		
		[TestCleanup]
		public void TearDown()
		{
			this.BuckarooClient = null;
		}

		/// <summary>
		///  Gets or sets the test context which provides
		///  information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }
	}
}
