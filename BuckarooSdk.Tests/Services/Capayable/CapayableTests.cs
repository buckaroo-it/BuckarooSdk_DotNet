using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.DataTypes.ParameterGroups.Capayable;
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
					ClientIp = new DataTypes.IpAddress()
					{
						Type = DataTypes.InternetProtocolVersion.IPv4,
						Address = "127.0.0.1"
					},
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
					CustomerType = "Debtor", // Mandatory
					InvoiceDate = DateTime.MinValue, // Mandatory
					Person = new Person
					{
						LastName = "de Tester",// Mandatory
						Initials = "JdT",// Mandatory
						Gender = 1,// Mandatory
						Culture = "nl-NL",// Mandatory
						BirthDate = DateTime.MinValue,// Mandatory
					},
					Address = new Address
					{
						Street = "Straatje",// Mandatory
						HouseNumber = 1,// Mandatory
						HouseNumberSuffix = string.Empty,
						ZipCode = "1234AB",// Mandatory
						City = "Stadje",// Mandatory
						Country = "NL",// Mandatory
					},
					Phone = new CustomerPhone
					{
						Phone = "11187654321",// Mandatory
						Fax = string.Empty,
					},
					Email = new EmailAddress
					{
						Email = "jan@jdt.nl",// Mandatory
					},
					Company = new Company
					{
						Name = string.Empty,
						ChamberOfCommerce = string.Empty,
					},
					ProductLine = new ProductLine
					{
						Code = "1234",// Mandatory
						Name = "ProductNaam",// Mandatory
						Quantity = 1,// Mandatory
						Price = 12,// Mandatory
					},
					SubTotalLine = new SubTotalLine
					{
						Name = string.Empty,
						Value = string.Empty,
					},
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
					ClientIp = new DataTypes.IpAddress()
					{
						Type = DataTypes.InternetProtocolVersion.IPv4,
						Address = "127.0.0.1"
					},
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
					ClientIp = new DataTypes.IpAddress()
					{
						Type = DataTypes.InternetProtocolVersion.IPv4,
						Address = "127.0.0.1"
					},
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
					CustomerType = "Debtor", // Mandatory
					InvoiceDate = DateTime.MinValue, // Mandatory
					Person = new Person
					{
						LastName = "de Tester",// Mandatory
						Initials = "JdT",// Mandatory
						Gender = 1,// Mandatory
						Culture = "nl-NL",// Mandatory
						BirthDate = DateTime.MinValue,// Mandatory
					},
					Address = new Address
					{
						Street = "Straatje",// Mandatory
						HouseNumber = 1,// Mandatory
						HouseNumberSuffix = string.Empty,
						ZipCode = "1234AB",// Mandatory
						City = "Stadje",// Mandatory
						Country = "NL",// Mandatory
					},
					Phone = new CustomerPhone
					{
						Phone = "11187654321",// Mandatory
						Fax = string.Empty,
					},
					Email = new EmailAddress
					{
						Email = "jan@jdt.nl",// Mandatory
					},
					Company = new Company
					{
						Name = string.Empty,
						ChamberOfCommerce = string.Empty,
					},
					ProductLine = new ProductLine
					{
						Code = "1234",// Mandatory
						Name = "ProductNaam",// Mandatory
						Quantity = 1,// Mandatory
						Price = 12,// Mandatory
					},
					SubTotalLine = new SubTotalLine
					{
						Name = string.Empty,
						Value = string.Empty,
					},
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


