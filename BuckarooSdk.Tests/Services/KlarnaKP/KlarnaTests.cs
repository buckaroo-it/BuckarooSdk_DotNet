using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.DataTypes.ParameterGroups.Klarna;
using BuckarooSdk.Services.KlarnaKP;
using System.Collections.Generic;
using BuckarooSdk.Services;
using System.Text;
using System.IO;

namespace BuckarooSdk.Tests.Services.KlarnaKP
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
		public void ReserveTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new ExtensiveLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase() // The transactionbase contains the base information of a transaction.
				{
					ClientIp = TestSettings.IpAddress,
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})

				.KlarnaKP() // Choose the paymentmethod you want to use
				.Reserve(Mocks.KlarnaKP.KlarnaKpReserveMock); // choose the action you want to use and provide the payment method specific info.

			var response = request.Execute();

			var logger = response.BuckarooSdkLogger;

			Process.Start(response.RequiredAction.RedirectURL);
			Console.WriteLine(logger.GetFullLog());
		}


		[TestMethod]
		public void CancelReservationTest()
		{
			var request =
				this._buckarooClient.CreateRequest(new ExtensiveLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase() // The transactionbase contains the base information of a transaction.
				{
					ClientIp = TestSettings.IpAddress,
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})

				.KlarnaKP() // Choose the paymentmethod you want to use
				.CancelReservation(Mocks.KlarnaKP.KlarnaKpCancelReservationMock); // choose the action you want to use and provide the payment method specific info.

			var response = request.Execute();

			var logger = response.BuckarooSdkLogger;

			//Process.Start(response.RequiredAction.RedirectURL);
			Console.WriteLine(logger.GetFullLog());
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
					AmountDebit = 0.4m,
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})
				.KlarnaKP() // Choose the paymentmethod you want to use
				.Pay(Mocks.KlarnaKP.KlarnaKpPayMock); // choose the action you want to use and provide the payment method specific info.

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
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
					OriginalTransactionKey = "12890D0FFE9F4840A69126DA2A93F1B6",
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					Order = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					AmountCredit = 0.40m,
				})
				.KlarnaKP() // Choose the paymentmethod you want to use
				.Refund(Mocks.KlarnaKP.KlarnaKpRefundMock); // choose the action you want to use and provide the payment method specific info.

			var response = request.Execute();

			// Process.Start(response.RequiredAction.RedirectURL);
			Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestMethod]
		public void UpdateReservationTests()
		{
			var request =
				this._buckarooClient.CreateRequest(new ExtensiveLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase() // The transactionbase contains the base information of a transaction.
				{
					ClientIp = TestSettings.IpAddress,
					Currency = "EUR",
					Description = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }",
				})

				.KlarnaKP() // Choose the paymentmethod you want to use
				.UpdateReservation(Mocks.KlarnaKP.KlarnaKpUpdateReservationMock); // choose the action you want to use and provide the payment method specific info.

			var response = request.Execute();
			var logger = response.BuckarooSdkLogger;

			//Process.Start(response.RequiredAction.RedirectURL);
			Console.WriteLine(logger.GetFullLog());
		}
	}
}
		//[TestMethod]
		//public void ReservePushTest()
		//{
		//	var pushHandler = this._buckarooClient.GetPushHandler(TestSettings.SecretKey); // Retrieving the pushHandler from de SDK client.

		//	using (var reader = new StreamReader($"{ TestSettings.LogBasePath }IdealPush.json"))
		//	{
		//		// JSON push as it is received by the client system.
		//		var jsonString = reader.ReadToEnd();
		//		var bodyAsBytes = Encoding.UTF8.GetBytes(jsonString);           // DEZE IS BELANGRIJK: BERICHT AS BYTE[]

		//		// calculate UNIX time
		//		var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
		//		var timeSpan = DateTime.UtcNow - epochStart;
		//		var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();
		//		// create random nonce for each request


		//		var pushSignature = this._buckarooClient.GetSignatureCalculationService().CalculateSignature(bodyAsBytes, HttpMethod.Post.ToString(),
		//			requestTimeStamp, Guid.NewGuid().ToString("N"),
		//			TestSettings.PushUri, TestSettings.WebsiteKey, TestSettings.SecretKey);


		//		var authorizationheader = $"hmac {pushSignature}";              // DEZE IS BELANGRIJK: SIGNATURE

		//		// Function that returns a structured push, based on the JSON pushed that is received.
		//		var push = pushHandler.DeserializePush(bodyAsBytes, TestSettings.PushUri, authorizationheader);

		//		var responseData = push.GetActionResponse<BuckarooSdk.Services.KlarnaKP.Push.KlarnaReservePush>();

		//		// 5 example values that can be retrieved from the push. The push contains many more though
		//		var transactionKey = push.Key;
		//		var transactionStatus = push.Status;

		//		var iban = responseData.ConsumerIban;
		//		var bic = responseData.ConsumerBic;
		//		var consumerName = responseData.ConsumerName;

		//		// The following KeyValuePair can be used to update your transaction
		//		var newTransactionStatus = new KeyValuePair<string, int>(transactionKey, transactionStatus.Code.Code);
		//	}
		//}

		//public void CapturePushTest()
		//{
		//	var pushHandler = this.BuckarooClient.GetPushHandler(TestSettings.SecretKey); // Retrieving the pushHandler from de SDK client.

		//	using (var reader = new StreamReader($"{ TestSettings.LogBasePath }IdealPush.json"))
		//	{
		//		// JSON push as it is received by the client system.
		//		var jsonString = reader.ReadToEnd();
		//		var bodyAsBytes = Encoding.UTF8.GetBytes(jsonString);           // DEZE IS BELANGRIJK: BERICHT AS BYTE[]

		//		// calculate UNIX time
		//		var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
		//		var timeSpan = DateTime.UtcNow - epochStart;
		//		var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();
		//		// create random nonce for each request


		//		var pushSignature = this.BuckarooClient.GetSignatureCalculationService().CalculateSignature(bodyAsBytes, HttpMethod.Post.ToString(),
		//			requestTimeStamp, Guid.NewGuid().ToString("N"),
		//			TestSettings.PushUri, TestSettings.WebsiteKey, TestSettings.SecretKey);


		//		var authorizationheader = $"hmac {pushSignature}";              // DEZE IS BELANGRIJK: SIGNATURE

		//		// Function that returns a structured push, based on the JSON pushed that is received.
		//		var push = pushHandler.DeserializePush(bodyAsBytes, TestSettings.PushUri, authorizationheader);

		//		var responseData = push.GetActionResponse<IdealPayPush>();

		//		// 5 example values that can be retrieved from the push. The push contains many more though
		//		var transactionKey = push.Key;
		//		var transactionStatus = push.Status;

		//		var iban = responseData.ConsumerIban;
		//		var bic = responseData.ConsumerBic;
		//		var consumerName = responseData.ConsumerName;

		//		// The following KeyValuePair can be used to update your transaction
		//		var newTransactionStatus = new KeyValuePair<string, int>(transactionKey, transactionStatus.Code.Code);
		//	}


		//}
		/**

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
				.Pay(new BucKlarnaKP.KlarnaPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					SendByEmail = false, // Mandatory
					PreserveReservation = false,
					ReservationNumber = "12345", // Mandatory
					SendByMail = false, // Mandatory
					Article = new Article
					{
						ArticleQuantity = 0,
						ArticleNumber = string.Empty,
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
					Article = new Article
					{
						ArticleQuantity = 0,
						ArticleNumber = string.Empty,
					},
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
					ReservationNumber = "12345678", // Mandatory
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
					BillingPhoneNumber = string.Empty,
					ShippingCity = string.Empty,
					ShippingCountry = string.Empty,
					BillingHouseNumber = string.Empty,
					ShippingLastName = string.Empty,
					ShippingCompany = string.Empty,
					BillingLastName = string.Empty,
					BillingCompanyName = string.Empty,
					BillingHouseNumberSuffix = string.Empty,
					BillingEmail = string.Empty,
					ShippingFirstName = string.Empty,
					ShippingCellPhoneNumber = string.Empty,
					BillingStreet = string.Empty,
					BillingCareOf = string.Empty,
					BillingPostalCode = string.Empty,
					BillingCountry = string.Empty,
					ShippingHouseNumberSuffix = string.Empty,
					ReservationNumber = "12345678", // Mandatory
					ShippingPostalCode = string.Empty,
					ShippingStreet = string.Empty,
					BillingCity = string.Empty,
					BillingCellPhoneNumber = string.Empty,
					ShippingHouseNumber = string.Empty,
					ShippingEmail = string.Empty,
					ShippingSameAsBilling = false,
					BillingFirstName = string.Empty,
					ShippingPhoneNumber = string.Empty,
					ShippingCareOf = string.Empty,
					Article = new Article
					{
						ArticlePrice = 0,
						ArticleQuantity = 0,
						ArticleNumber = string.Empty,
						ArticleDiscount = 0,
						ArticleTitle = "Article title",// Mandatory
						ArticleVat = 0,
					},
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
					OperatingCountry = "NL", // Mandatory
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


	**/