using BuckarooSdk.Services.PayPal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.PayPal
{
	[TestClass]
	public class PayPalTests
	{
		private SdkClient _sdkClient;

		[TestInitialize]
		public void Setup()
		{
			this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
		}

		[TestMethod]
		public void PayTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "PAYPAL_PAY_SDK_UNITTEST",
				})
				.PayPal()
				.Pay(new PayPalPayRequest()
				{
					//define properties
					BuyerEmail = "techsup@buckaroo.nl",
					ProductName = "haardhout",
				});

			var paymentResponse = request.Execute();
		}

		[TestMethod]
		public void RefundTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
				})
				.PayPal()

				.Refund(new PayPalRefundRequest()
				{
					//define properties

				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRecurrentTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
				})
				.PayPal()

				.PayRecurrent(new PayPalPayRecurrentRequest()
				{
					//define properties

				});
			
			var response = request.Execute();
		}

		[TestMethod]
		[Ignore]
		public void PayRemainderTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
				})
				.PayPal()

				.PayRemainder(new PayPalPayRemainderRequest
				{
					//define properties
					BuyerEmail = "techsup@buckaroo.nl",

				});

			var response = request.Execute();
		}

		[TestMethod]
		public void ExtraInfoTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new RequestObject
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
				})
				.PayPal()
				.ExtraInfo(new PayPalExtraInfoRequest
				{
					//define properties
				});
			
			var response = request.Execute();
		}
	}
}
