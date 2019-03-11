using System;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.IdealProcessing.TransactionRequest;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.IdealProcessing
{
	[TestClass]
	public class IdealProcessingTests
	{ 
		internal SdkClient BuckarooClient { get; private set; }

		[TestInitialize]
		public void Setup()
		{
			this.BuckarooClient = new SdkClient(TestSettings.Logger);
		}
		[TestMethod]
		public void PayTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
				})
				.IdealProcessing()
				.Pay(new IdealProcessingPayRequest
				{
					Issuer = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
				});

			var response = request.Execute();

			Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
	}
}
