using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.SimpleSepaDirectDebit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.SimpleSepaDirectDebit
{
	[TestClass]
	public class SimpleSepaDirectDebitTests
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
					Description = "SIMPLESEPADIRECTDEBIT_PAY_SDK_UNITTEST",
					StartRecurrent = true,

				})
				.SimpleSepaDirectDebit()
				.Pay(new SimpleSepaDirectDebitPayRequest()
				{
					MandateReference = "0012652668455265",
					MandateDate = "16-11-2016",
					CustomerIban = "NL88INGB0757641768",
					CustomerBic = "INGBNL2A",
					CustomerAccountName = "JJA Roos",
					CollectDate = "26-11-2016",
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
					Description = "SIMPLESEPADIRECTDEBIT_REFUND_SDK_UNITTEST",

				})
				.SimpleSepaDirectDebit()

				.Refund(new SimpleSepaDirectDebitRefundRequest()
				{
					CustomerIban = "NL88INGB0757641768",
					CustomerBic = "INGBNL2A",
					CustomerAccountName = "JJA Roos",
				});

			var response = request.Execute();
		}
	}
}
