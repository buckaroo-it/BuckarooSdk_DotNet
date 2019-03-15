using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.Services.AfterpayAcceptgiro;

namespace BuckarooSdk.Tests.Services.AfterpayAcceptgiro
{
	[TestClass]
	public class AfterpayAcceptgiroTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(AfterpayAcceptgiroTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(TestSettings.Logger);
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
				.AfterpayAcceptgiro() // Choose the paymentmethod you want to use
				.Pay(new AfterpayAcceptgiroPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					ShippingCosts = 0,
					Discount = 0,
					Accept = false, // Mandatory
					BillingTitle = string.Empty,
					BillingGender = 0,
					BillingInitials = string.Empty,
					BillingLastNamePrefix = string.Empty,
					BillingLastName = string.Empty,
					BillingBirthDate = DateTime.MinValue,
					BillingStreet = string.Empty,
					BillingHouseNumber = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					BillingPostalCode = string.Empty,
					BillingCity = string.Empty,
					BillingCountry = string.Empty,
					BillingEmail = string.Empty,
					BillingPhoneNumber = string.Empty,
					BillingLanguage = string.Empty,
					ShippingTitle = string.Empty,
					ShippingGender = 0,
					ShippingInitials = string.Empty,
					ShippingLastNamePrefix = string.Empty,
					ShippingLastName = string.Empty,
					ShippingBirthDate = string.Empty,
					ShippingStreet = string.Empty,
					ShippingHouseNumber = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingPostalCode = string.Empty,
					ShippingCity = string.Empty,
					ShippingCountryCode = string.Empty,
					ShippingEmail = string.Empty,
					ShippingPhoneNumber = string.Empty,
					ShippingLanguage = string.Empty,
					AddressesDiffer = false,
					B2B = false,
					CustomerAccountNumber = string.Empty,
					CompanyCOCRegistration = string.Empty,
					CommissionAmount = 0,
					CompanyName = string.Empty,
					CostCentre = string.Empty,
					Department = string.Empty,
					EstablishmentNumber = string.Empty,
					CustomerIPAddress = string.Empty,
					VatNumber = string.Empty,
					ArticleDescription = string.Empty,
					ArticleId = string.Empty,
					ArticleQuantity = 0,
					ArticleUnitprice = 0,
					ArticleVatcategory = 0,
					ArticleNetUnitprice = 0,

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
				.AfterpayAcceptgiro() // Choose the paymentmethod you want to use
				.Refund(new AfterpayAcceptgiroRefundRequest // choose the action you want to use and provide the payment method specific info.
				{
					ArticleDescription = string.Empty,
					ArticleId = string.Empty,
					ArticleQuantity = 0,
					ArticleUnitprice = 0,
					ArticleVatcategory = 0,
					ArticleNetUnitprice = 0,

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
				.AfterpayAcceptgiro() // Choose the paymentmethod you want to use
				.Authorize(new AfterpayAcceptgiroAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
				{
					Discount = 0,
					Accept = false, // Mandatory
					ShippingCosts = 0,
					BillingTitle = string.Empty,
					BillingGender = 0,
					BillingInitials = string.Empty,
					BillingLastNamePrefix = string.Empty,
					BillingLastName = string.Empty,
					BillingBirthDate = DateTime.MinValue,
					BillingStreet = string.Empty,
					BillingHouseNumber = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					BillingPostalCode = string.Empty,
					BillingCity = string.Empty,
					BillingCountry = string.Empty,
					BillingEmail = string.Empty,
					BillingPhoneNumber = string.Empty,
					BillingLanguage = string.Empty,
					ShippingTitle = string.Empty,
					ShippingGender = 0,
					ShippingInitials = string.Empty,
					ShippingLastNamePrefix = string.Empty,
					ShippingLastName = string.Empty,
					ShippingBirthDate = string.Empty,
					ShippingStreet = string.Empty,
					ShippingHouseNumber = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingPostalCode = string.Empty,
					ShippingCity = string.Empty,
					ShippingCountryCode = string.Empty,
					ShippingEmail = string.Empty,
					ShippingPhoneNumber = string.Empty,
					ShippingLanguage = string.Empty,
					AddressesDiffer = false,
					B2B = false,
					CustomerAccountNumber = string.Empty,
					CompanyCOCRegistration = string.Empty,
					CommissionAmount = 0,
					CompanyName = string.Empty,
					CostCentre = string.Empty,
					Department = string.Empty,
					EstablishmentNumber = string.Empty,
					CustomerIPAddress = string.Empty,
					VatNumber = string.Empty,
					ArticleDescription = string.Empty,
					ArticleId = string.Empty,
					ArticleQuantity = 0,
					ArticleUnitprice = 0,
					ArticleVatcategory = 0,
					ArticleNetUnitprice = 0,

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
				.AfterpayAcceptgiro() // Choose the paymentmethod you want to use
				.Capture(new AfterpayAcceptgiroCaptureRequest // choose the action you want to use and provide the payment method specific info.
				{
					ArticleDescription = string.Empty,
					ArticleId = string.Empty,
					ArticleQuantity = 0,
					ArticleUnitprice = 0,
					ArticleVatcategory = 0,
					ArticleNetUnitprice = 0,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
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
				.AfterpayAcceptgiro() // Choose the paymentmethod you want to use
				.CancelAuthorize(new AfterpayAcceptgiroCancelAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
				{

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


