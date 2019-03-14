using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.EMandate;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.EMandate
{
	[TestClass]
	public class EMandateTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(EMandateTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void CreateMandateTest()
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

				})
				.EMandate() // Choose the paymentmethod you want to use
				.CreateMandate(new EMandateCreateMandateRequest // choose the action you want to use and provide the payment method specific info.
				{
					EMandateReason = string.Empty,
					SequenceType = 0,
					PurchaseId = string.Empty,
					DebtorBankId = string.Empty,
					MandateId = string.Empty,
					DebtorReference = string.Empty,
					Language = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void GetIssuerListTest()
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

				})
				.EMandate() // Choose the paymentmethod you want to use
				.GetIssuerList(new EMandateGetIssuerListRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void GetStatusTest()
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

				})
				.EMandate() // Choose the paymentmethod you want to use
				.GetStatus(new EMandateGetStatusRequest // choose the action you want to use and provide the payment method specific info.
				{
					MandateId = string.Empty,
				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void ModifyMandateTest()
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

				})
				.EMandate() // Choose the paymentmethod you want to use
				.ModifyMandate(new EMandateModifyMandateRequest // choose the action you want to use and provide the payment method specific info.
				{
					OriginalIBAN = string.Empty,
					PurchaseId = string.Empty,
					OriginalDebtorBankId = string.Empty,
					EMandateReason = string.Empty,
					SequenceType = 0,
					OriginalMandateId = string.Empty,
					DebtorBankId = string.Empty,
					Language = string.Empty,
					DebtorReference = string.Empty,
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


