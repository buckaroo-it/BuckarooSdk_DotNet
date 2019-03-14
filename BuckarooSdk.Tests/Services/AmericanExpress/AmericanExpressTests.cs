using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.CreditCards.AmericanExpress.Constants;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.CreditCards.AmericanExpress.Request;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.AmericanExpress
{
	[TestClass]
	public class AmericanExpressTests

	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(AmericanExpressTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(Constants.TestSettings.Logger);
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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.Pay(new AmericanExpressPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					RecurringInterval = 0,
					ShippingMethodCode = string.Empty,
					Recurring = string.Empty,
					CustomerIPAddress = string.Empty,
					VerifyAddress = false,
					CustomerHTTPBrowserType = string.Empty,
					CustomerHostServerName = string.Empty,
					RecurringTimeType = string.Empty,
					CustomerCardName = string.Empty,
					AmexCreditcardNumber = string.Empty,
					CVV4 = string.Empty,
					ShippingFirstName = string.Empty,
					ShippingLastName = string.Empty,
					ShippingStreet = string.Empty,
					CardExpirationDate = DateTime.MinValue,
					ShippingHouseNumber = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingPostalCode = string.Empty,
					ShippingCountryCode = string.Empty,
					ShippingPhoneNumber = string.Empty,
					CustomerEmail = string.Empty,
					BillingFirstName = string.Empty,
					BillingLastName = string.Empty,
					BillingStreet = string.Empty,
					BillingHouseNumber = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					BillingPostalCode = string.Empty,
					BillingPhoneNumber = string.Empty,
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
					OriginalTransactionKey = string.Empty,
					AmountCredit = 2,
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.AmericanExpress() // Choose the paymentmethod you want to use
				.Refund(new AmericanExpressRefundRequest // choose the action you want to use and provide the payment method specific info.
				{

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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.Authorize(new AmericanExpressAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
				{
					RecurringInterval = 0,
					ShippingMethodCode = string.Empty,
					Recurring = string.Empty,
					CustomerIPAddress = string.Empty,
					VerifyAddress = false,
					CustomerHTTPBrowserType = string.Empty,
					CustomerHostServerName = string.Empty,
					RecurringTimeType = string.Empty,
					ShippingFirstName = string.Empty,
					ShippingLastName = string.Empty,
					ShippingStreet = string.Empty,
					ShippingHouseNumber = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingPostalCode = string.Empty,
					ShippingCountryCode = string.Empty,
					ShippingPhoneNumber = string.Empty,
					CustomerEmail = string.Empty,
					BillingFirstName = string.Empty,
					BillingLastName = string.Empty,
					BillingStreet = string.Empty,
					BillingHouseNumber = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					BillingPostalCode = string.Empty,
					BillingPhoneNumber = string.Empty,

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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.Capture(new AmericanExpressCaptureRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void PayRecurrentTest()
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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.PayRecurrent(new AmericanExpressPayRecurrentRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void PayEncryptedTest()
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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.PayEncrypted(new AmericanExpressPayEncryptedRequest // choose the action you want to use and provide the payment method specific info.
				{
					EncryptedCardData = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void AuthorizeEncryptedTest()
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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.AuthorizeEncrypted(new AmericanExpressAuthorizeEncryptedRequest // choose the action you want to use and provide the payment method specific info.
				{
					EncryptedCardData = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void PayRemainderTest()
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
				.AmericanExpress() // Choose the paymentmethod you want to use
				.PayRemainder(new AmericanExpressPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
				{
					RecurringInterval = 0,
					ShippingMethodCode = string.Empty,
					Recurring = string.Empty,
					CustomerIPAddress = string.Empty,
					VerifyAddress = false,
					CustomerHTTPBrowserType = string.Empty,
					CustomerHostServerName = string.Empty,
					RecurringTimeType = string.Empty,
					ShippingFirstName = string.Empty,
					ShippingLastName = string.Empty,
					ShippingStreet = string.Empty,
					ShippingHouseNumber = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingPostalCode = string.Empty,
					ShippingCountryCode = string.Empty,
					ShippingPhoneNumber = string.Empty,
					CustomerEmail = string.Empty,
					BillingFirstName = string.Empty,
					BillingLastName = string.Empty,
					BillingStreet = string.Empty,
					BillingHouseNumber = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					BillingPostalCode = string.Empty,
					BillingPhoneNumber = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

	}
}
