using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.Thunes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Thunes
{
	[TestClass]
	public class ThunesTests
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
				.Thunes()
				.Pay(new ThunesBaseRequest()
				{
					ArticleID = "ID1",
					ArticleLabel = "Hamburger",
					ArticleUnitPrice = "0.02"
				}, ThunesServiceType.MonizzeEcoVoucher);

			var paymentResponse = payment.Execute();
		}
	}
}
