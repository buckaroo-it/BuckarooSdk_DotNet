using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.Services.Afterpay;

namespace BuckarooSdk.Tests.Services.Afterpay
{
	[TestClass]
	public class AfterpayTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(AfterpayTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void CancelAuthorizeTest()
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
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					OriginalTransactionKey = "",
					AmountCredit = 2,
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Afterpay() // Choose the paymentmethod you want to use
				.CancelAuthorize(new AfterpayCancelAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void PayTest()
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
				.Afterpay() // Choose the paymentmethod you want to use
				.Pay(new AfterpayPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					VatCategory = string.Empty,
					MerchantImageUrl = string.Empty,
					GrossUnitPrice = 0, // Mandatory
					ImageUrl = string.Empty,
					IdentificationNumber = string.Empty,
					SummaryImageUrl = string.Empty,
					Description = string.Empty, // Mandatory
					Phone = string.Empty,
					FirstName = string.Empty,
					CareOf = string.Empty,
					Url = string.Empty,
					Email = string.Empty,
					PostalCode = string.Empty,
					MobilePhone = string.Empty,
					BankCode = string.Empty,
					CustomerNumber = string.Empty,
					Quantity = string.Empty, // Mandatory
					UnitCode = string.Empty,
					Street = string.Empty,
					BirthDate = DateTime.MinValue,
					Type = string.Empty,
					BankAccount = string.Empty,
					Salutation = string.Empty,
					StreetNumberAdditional = string.Empty,
					ConversationLanguage = string.Empty,
					City = string.Empty,
					Category = string.Empty,
					VatPercentage = 0, // Mandatory
					Country = string.Empty,
					LastName = string.Empty,
					Identifier = string.Empty,
					StreetNumber = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void RefundTest()
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
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					OriginalTransactionKey = "",
					AmountCredit = 2,
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Afterpay() // Choose the paymentmethod you want to use
				.Refund(new AfterpayRefundRequest // choose the action you want to use and provide the payment method specific info.
				{
					Url = string.Empty,
					Quantity = string.Empty,
					UnitCode = string.Empty,
					Type = string.Empty,
					RefundType = string.Empty,
					VatPercentage = 0,
					VatCategory = string.Empty,
					GrossUnitPrice = 0,
					ImageUrl = string.Empty,
					Description = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void AuthorizeTest()
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
				.Afterpay() // Choose the paymentmethod you want to use
				.Authorize(new AfterpayAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
				{
					ImageUrl = string.Empty,
					BankCode = string.Empty,
					Url = string.Empty,
					PostalCode = string.Empty,
					BankAccount = string.Empty,
					Salutation = string.Empty,
					Quantity = string.Empty, // Mandatory
					FirstName = string.Empty,
					Street = string.Empty,
					UnitCode = string.Empty,
					Category = string.Empty,
					Type = string.Empty,
					MobilePhone = string.Empty,
					StreetNumberAdditional = string.Empty,
					IdentificationNumber = string.Empty,
					MerchantImageUrl = string.Empty,
					VatPercentage = 0, // Mandatory
					Country = string.Empty,
					Identifier = string.Empty,
					BirthDate = DateTime.MinValue,
					StreetNumber = string.Empty,
					LastName = string.Empty,
					Email = string.Empty,
					VatCategory = string.Empty,
					City = string.Empty,
					ConversationLanguage = string.Empty,
					SummaryImageUrl = string.Empty,
					GrossUnitPrice = 0, // Mandatory
					Phone = string.Empty,
					CareOf = string.Empty,
					CustomerNumber = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		[TestMethod]
		public void CaptureTest()
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
					OriginalTransactionKey = "",
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Afterpay() // Choose the paymentmethod you want to use
				.Capture(new AfterpayCaptureRequest // choose the action you want to use and provide the payment method specific info.
				{
					GrossUnitPrice = 0,
					MerchantImageUrl = string.Empty,
					ImageUrl = string.Empty,
					Description = string.Empty,
					SummaryImageUrl = string.Empty,
					Url = string.Empty,
					Quantity = string.Empty,
					UnitCode = string.Empty,
					Type = string.Empty,
					VatPercentage = 0,
					Identifier = string.Empty,

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


