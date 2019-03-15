using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.OnlineGiroLite;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.OnlineGiroLite
{
	[TestClass]
	public class OnlineGiroLiteTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(OnlineGiroLiteTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void PaymentInvitationTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest() // One of the request type options.
				.SetBasicFields(new TransactionBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					AmountDebit = 2,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.OnlineGiroLite() // Choose the paymentmethod you want to use
				.PaymentInvitation(new OnlineGiroLitePaymentInvitationRequest // choose the action you want to use and provide the payment method specific info.
				{
					CustomerGender = 0, // Mandatory
					CustomerFirstName = "Jan", // Mandatory
					CustomerLastName = "de Tester", // Mandatory
					CustomerEmail = "jan@detester.com", // Mandatory
					ExpirationDate = DateTime.MinValue,
					Attachment = string.Empty,
				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestCleanup]
		public void TearDown()
		{
			this._buckarooClient = null;
		}
	}
}


