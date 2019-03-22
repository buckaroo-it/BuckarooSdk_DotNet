using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.Klarna;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Klarna
{
	[TestClass]
	public class KlarnaTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(KlarnaTests).ToUpper();

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
				.Klarna() // Choose the paymentmethod you want to use
				.Pay(new KlarnaPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					ReservationNumber = string.Empty, // Mandatory
					ArticleQuantity = 0,
					ArticleNumber = string.Empty,
					SendByMail = false, // Mandatory
					SendByEmail = false, // Mandatory
					PreserveReservation = false,

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
				.Klarna() // Choose the paymentmethod you want to use
				.Refund(new KlarnaRefundRequest // choose the action you want to use and provide the payment method specific info.
				{
					ArticleQuantity = 0,
					ArticleNumber = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void ReserveTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Klarna() // Choose the paymentmethod you want to use
				.Reserve(new KlarnaReserveRequest // choose the action you want to use and provide the payment method specific info.
				{
					ArticleType = string.Empty,
					ArticlePrice = 0,
					BillingCareOf = string.Empty,
					Encoding = string.Empty,
					BillingLastName = string.Empty,
					Gender = 0,
					BillingCountry = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					ShippingFirstName = string.Empty,
					PClass = 0,
					ArticleQuantity = 0,
					BillingCellPhoneNumber = string.Empty,
					OperatingCountry = string.Empty, // Mandatory
					BillingStreet = string.Empty,
					Pno = string.Empty, // Mandatory
					BillingCity = string.Empty,
					BillingPostalCode = string.Empty,
					ArticleNumber = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingSameAsBilling = false,
					ShippingEmail = string.Empty,
					ShippingCareOf = string.Empty,
					ShippingPostalCode = string.Empty,
					ArticleDiscount = 0,
					ShippingPhoneNumber = string.Empty,
					ShippingStreet = string.Empty,
					ArticleTitle = string.Empty, // Mandatory
					ShippingHouseNumber = string.Empty,
					ShippingCountry = string.Empty,
					ShippingCity = string.Empty,
					ShippingCompany = string.Empty,
					BillingFirstName = string.Empty,
					ShippingLastName = string.Empty,
					ArticleVat = 0,
					BillingCompanyName = string.Empty,
					BillingPhoneNumber = string.Empty,
					BillingEmail = string.Empty,
					ShippingCellPhoneNumber = string.Empty,
					BillingHouseNumber = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void CancelReservationTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Klarna() // Choose the paymentmethod you want to use
				.CancelReservation(new KlarnaCancelReservationRequest // choose the action you want to use and provide the payment method specific info.
				{
					ReservationNumber = string.Empty, // Mandatory

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void UpdateReservationTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Klarna() // Choose the paymentmethod you want to use
				.UpdateReservation(new KlarnaUpdateReservationRequest // choose the action you want to use and provide the payment method specific info.
				{
					ShippingCellPhoneNumber = string.Empty,
					ArticleNumber = string.Empty,
					BillingLastName = string.Empty,
					BillingCareOf = string.Empty,
					BillingCountry = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					ShippingFirstName = string.Empty,
					ArticleDiscount = 0,
					ReservationNumber = string.Empty, // Mandatory
					ArticleTitle = string.Empty, // Mandatory
					BillingStreet = string.Empty,
					BillingCellPhoneNumber = string.Empty,
					BillingCity = string.Empty,
					BillingPostalCode = string.Empty,
					ArticleVat = 0,
					ShippingHouseNumberSuffix = string.Empty,
					ShippingEmail = string.Empty,
					ShippingSameAsBilling = false,
					ShippingPostalCode = string.Empty,
					ShippingCareOf = string.Empty,
					ShippingPhoneNumber = string.Empty,
					ShippingStreet = string.Empty,
					ArticlePrice = 0,
					ShippingHouseNumber = string.Empty,
					ShippingCity = string.Empty,
					ShippingCountry = string.Empty,
					BillingFirstName = string.Empty,
					ShippingLastName = string.Empty,
					ShippingCompany = string.Empty,
					ArticleQuantity = 0,
					BillingPhoneNumber = string.Empty,
					BillingEmail = string.Empty,
					BillingCompanyName = string.Empty,
					BillingHouseNumber = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void GetPClassesTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.Klarna() // Choose the paymentmethod you want to use
				.GetPClasses(new KlarnaGetPClassesRequest // choose the action you want to use and provide the payment method specific info.
				{
					Encoding = string.Empty,
					OperatingCountry = string.Empty, // Mandatory

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


