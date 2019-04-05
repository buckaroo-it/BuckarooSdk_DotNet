using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.Services.CustomGiftcard;

namespace BuckarooSdk.Tests.Services.CustomGiftcard
{
	[TestClass]
	public class CustomGiftcardTests
	{
		private SdkClient _buckarooClient;
		private string TestName => nameof(CustomGiftcardTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(TestSettings.Logger);
		}

		#region CustomGiftcard
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
				.CustomGiftcard() // Choose the paymentmethod you want to use
				.Pay(new CustomGiftcardPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty, // Mandatory

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
				.CustomGiftcard() // Choose the paymentmethod you want to use
				.Refund(new CustomGiftcardRefundRequest // choose the action you want to use and provide the payment method specific info.
				{

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
				.CustomGiftcard() // Choose the paymentmethod you want to use
				.PayRemainder(new CustomGiftcardPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty, // Mandatory

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void CardInfoTest()
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

				})
				.CustomGiftcard() // Choose the paymentmethod you want to use
				.CardInfo(new CustomGiftcardCardInfoRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		#endregion

		#region CustomGiftcard2
		[TestMethod]
		public void PayTest2()
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
				.CustomGiftcard2() // Choose the paymentmethod you want to use
				.Pay(new CustomGiftcardPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 7000001184904198006, // Mandatory
					Pin = "368082", // Mandatory

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void RefundTest2()
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
				.CustomGiftcard2() // Choose the paymentmethod you want to use
				.Refund(new CustomGiftcardRefundRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void PayRemainderTest2()
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
				.CustomGiftcard2() // Choose the paymentmethod you want to use
				.PayRemainder(new CustomGiftcardPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty, // Mandatory

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void CardInfoTest2()
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

				})
				.CustomGiftcard2() // Choose the paymentmethod you want to use
				.CardInfo(new CustomGiftcardCardInfoRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		#endregion

		#region CustomGiftcard3
		[TestMethod]
		public void PayTest3()
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
				.CustomGiftcard3() // Choose the paymentmethod you want to use
				.Pay(new CustomGiftcardPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty, // Mandatory

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void RefundTest3()
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
				.CustomGiftcard3() // Choose the paymentmethod you want to use
				.Refund(new CustomGiftcardRefundRequest // choose the action you want to use and provide the payment method specific info.
				{

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void PayRemainderTest3()
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
				.CustomGiftcard3() // Choose the paymentmethod you want to use
				.PayRemainder(new CustomGiftcardPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty, // Mandatory

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void CardInfoTest3()
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

				})
				.CustomGiftcard3() // Choose the paymentmethod you want to use
				.CardInfo(new CustomGiftcardCardInfoRequest // choose the action you want to use and provide the payment method specific info.
				{
					CardNumber = 0, // Mandatory
					Pin = string.Empty,

				});

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			// Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}
		#endregion


		[TestCleanup]
		public void TearDown()
		{
			this._buckarooClient = null;
		}
	}
}


