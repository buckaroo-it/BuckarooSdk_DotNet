using System;
using BuckarooSdk.Services.CreditCards.Request;
using BuckarooSdk.Services.CreditCards.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Tests.Services.CreditCard
{
	[TestClass]
	public class CreditCardTests
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
					}
					.AddAdditionalParameter("add_test1", DateTime.Now.Ticks.ToString())
					.AddAdditionalParameter("add_test2", "test")
				)
				.Maestro()
				.Pay(new CreditCardPayRequest(BuckarooSdk.Constants.Service.ServiceNames));

			var response = request.Execute();
		}
	}
}
