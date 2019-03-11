using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.Transfer.TransactionRequest;

namespace BuckarooSdk.Tests.Services.Transfer
{
	[TestClass]
	public class TransferTests
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
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "TRANSFER_PAY_SDK_UNITTEST",

				})
				.Transfer()

				.Pay(new TransferPayRequest()
				{
					CustomerEmail = "techsup@buckaroo.nl",
					SendMail = true,
					CustomerCountry = "NL",
					CustomerGender = BuckarooSdk.Services.Transfer.Constants.Gender.Male,
					CustomerFirstName = "Sjaak",
					CustomerLastName = "Roos",
				});

			var response = request.Execute();
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
					Invoice = "SDK_TEST_636148974088928502",
					OriginalTransactionKey = "F7C50D3B18E44FE7B87461B68891B3F2",
					Description = "TRANFER_REFUND_SDK_UNITTEST",
				})
				.Transfer()

				.Refund(new TransferRefundRequest()
				{
					CustomerIban = "NL88INGB0757641768",
					CustomerBic = "INGBNL2A",
					CustomerAccountname = "JJA Roos",

				});

			var response = request.Execute();
		}
	}
}
