using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using BuckarooSdk.Services.Capayable;

namespace BuckarooSdk.Tests.Services.Capayable
{
	[TestClass]
	public class CapayableTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(CapayableTests).ToUpper();

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
				.Capayable() // Choose the paymentmethod you want to use
				.Pay(new CapayablePayRequest // choose the action you want to use and provide the payment method specific info.
				{
					CustomerType = string.Empty, // Mandatory
					LastName = string.Empty, // Mandatory
					Initials = string.Empty, // Mandatory
					Culture = string.Empty, // Mandatory
					Gender = 0, // Mandatory
					BirthDate = DateTime.MinValue, // Mandatory
					Street = string.Empty, // Mandatory
					HouseNumber = 0, // Mandatory
					HouseNumberSuffix = string.Empty,
					ZipCode = string.Empty, // Mandatory
					City = string.Empty, // Mandatory
					Country = string.Empty, // Mandatory
					Phone = string.Empty, // Mandatory
					Fax = string.Empty,
					Email = string.Empty, // Mandatory
					ChamberOfCommerce = string.Empty,
					InvoiceDate = DateTime.MinValue, // Mandatory
					Code = string.Empty, // Mandatory
					Quantity = 0, // Mandatory
					Price = 0, // Mandatory
					Name = string.Empty,
					Value = string.Empty,
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
				.Capayable() // Choose the paymentmethod you want to use
				.Refund(new CapayableRefundRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void PayInInstallmentsTest()
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
				})
				.Capayable() // Choose the paymentmethod you want to use
				.PayInInstallments(new CapayablePayInInstallmentsRequest // choose the action you want to use and provide the payment method specific info.
				{
					IsInThreeGuarantee = string.Empty,
					CustomerType = string.Empty, // Mandatory
					LastName = "de Tester", // Mandatory
					Initials = "J", // Mandatory
					Gender = 1, // Mandatory
					Culture = "nl-NL", // Mandatory
					BirthDate = new DateTime(1966, 12, 12), // Mandatory
					Street = "Straatnaam", // Mandatory
					HouseNumber = 1, // Mandatory
					HouseNumberSuffix = string.Empty,
					ZipCode = "1234AB", // Mandatory
					City = "Stadje", // Mandatory
					Country = "NL", // Mandatory
					Phone = "00012345678", // Mandatory
					Fax = string.Empty,
					Email = "jan@jdt.com", // Mandatory
					ChamberOfCommerce = string.Empty,
					InvoiceDate = new DateTime(2020, 12, 12), // Mandatory
					Code = string.Empty, // Mandatory
					Quantity = 1, // Mandatory
					Price = 12, // Mandatory
					Name = string.Empty,
					Value = string.Empty,
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