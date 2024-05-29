using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.PaymentInitiation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.PaymentInitiation
{
	[TestClass]
	public class PaymentInitiationTests
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
					Description = "PAYBYBANK_PAY_SDK_UNITTEST",
					StartRecurrent = true,

				})
				.PaymentInitiation()
				.Pay(new PaymentInitiationPayRequest()
				{
					Issuer = "RABONL2U",
					CountryCode = "NL"
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
					Description = "PAYBYBANK_REFUND_SDK_UNITTEST",

				})
				.PaymentInitiation()
				.Refund(new PaymentInitiationRefundRequest()
				{
				});

			var response = request.Execute();
		}
	}
}
