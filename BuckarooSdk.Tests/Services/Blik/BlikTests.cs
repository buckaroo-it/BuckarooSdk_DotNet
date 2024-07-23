using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.Blik;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Blik
{
	[TestClass]
	public class BlikTests
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
			var payment = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "BLIK_PAY_SDK_UNITTEST",
					StartRecurrent = true,

				})
				.Blik()
				.Pay(new BlikPayRequest()
				{
					Email = "test@gmail.com"
				});

			var paymentResponse = payment.Execute();
		}

		[TestMethod]
		public void RefundTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					AmountCredit = 0.02m,
					Currency = "EUR",
					Invoice = "",
					OriginalTransactionKey = "",
					Description = "BLIK_REFUND_SDK_UNITTEST",

				})
				.Blik()
				.Refund(new BlikRefundRequest()
				{
				});

			var response = request.Execute();
		}
	}
}
