using System;
using System.Collections.Generic;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.CreditManagement.DataRequest;
using BuckarooSdk.Services.CreditManagement.TransactionRequest;
using BuckarooSdk.Services.Ideal.Push;
using BuckarooSdk.Tests.Constants;

namespace BuckarooSdk.Tests.Services.Ideal
{
	[TestClass]
	public class IdealTests
	{
		public SdkClient BuckarooClient { get; private set; }

		[TestInitialize]
		public void Setup()
		{
			this.BuckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void PayTest()
		{
			var request = 
				this.BuckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest() // One of the request type options.
				.SetBasicFields(new TransactionBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
				})
				.Ideal() // Choose the paymentmethod you want to use
				.Pay(new IdealPayRequest // choose the action you want to use and provide the payment method specific info.
				{
					Issuer = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
				});

			var response = request.Execute();

			Process.Start(response.RequiredAction.RedirectURL);

			Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		[TestCleanup]
		public void TearDown()
		{
			this.BuckarooClient = null;
		}

		[TestMethod]
		public void PayWithCreditManagementTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,

				})

				.Ideal()
				.Pay(new IdealPayRequest()
				{
					Issuer = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
				})
				.AddAdditionalService()
				.CreditManagement()
				.CreateCombinedInvoice(new CreditManagementInvoiceRequest
				{
					InvoiceDate = DateTime.Now,
					DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(10),
					SchemeKey = "DefaultNone",
					InvoiceAmount = 0.05m,
					Debtor = new Debtor
					{
						Code = "20161124",
					},
					Person = new Person
					{
						Initials = "JJA",
						FirstName = "Sjaak",
						LastName = "Roos",
						Gender = BuckarooSdk.Services.CreditManagement.Constants.Gender.Male,
						Culture = "nl-NL",
					},
					Address = new Address
					{
						Street = "Plantijnstraat",
						HouseNumber = "91",
						ZipCode = "2321 JH",
						City = "Leiden",
						Country = "NL"
					},
					Email = new EmailAddress
					{
						Email = "techsup@buckaroo.nl",
					},
					Phone = new Phone
					{
						Mobile = "0613575514",
					},
				});

			var response = request.Execute();

			if (response.Status.Code.Code == BuckarooSdk.Constants.Status.Success)
			{
				Process.Start("http://www.google.com");
			}

			var idealActionResponse = response.GetActionResponse<IdealPayResponse>();
			var redirectUrl = response.RequiredAction.RedirectURL;

			var creditManagementActionResponse = response.GetActionResponse<CreditManagementCreateInvoiceResponse>();
		}

		[TestMethod]
		public void RefundTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))

				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					AmountCredit = 0.02m,
					Currency = "EUR",
					Invoice = "SDK_TEST_636196508460881929", //set before each refund test
					OriginalTransactionKey = "DDE3795437444D2AB1B803EA829C89E5", //set before each refund test
					Description = "IDEAL_REFUND_SDK_UNITTEST",
				})
				.Ideal()
				.Refund(new IdealRefundRequest());

			var response = request.Execute();

			var logging = response.BuckarooSdkLogger.GetFullLog();
			Console.WriteLine(logging);
		}

		[TestMethod]
		[Ignore]
		public void PayRemainderTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					AmountDebit = 0.02m,
					Currency = "EUR",
					Invoice = "SDK_TEST_636156814261631001",
					Description = "IDEAL_PAYREMAINDER_SDK_UNITTEST",
				})
				.Ideal()

				.PayRemainder(new IdealPayRemainderRequest()
				{
					Issuer = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayPushTest()
		{
			var pushHandler = this.BuckarooClient.GetPushHandler(TestSettings.SecretKey); // Retrieving the pushHandler from de SDK client.

			using (var reader = new StreamReader($"{ TestSettings.LogBasePath }IdealPush.json"))
			{
				// JSON push as it is received by the client system.
				var jsonString = reader.ReadToEnd();						
				var bodyAsBytes = Encoding.UTF8.GetBytes(jsonString);           // DEZE IS BELANGRIJK: BERICHT AS BYTE[]

				// calculate UNIX time
				var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
				var timeSpan = DateTime.UtcNow - epochStart;
				var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();
				// create random nonce for each request


				var pushSignature = this.BuckarooClient.GetSignatureCalculationService().CalculateSignature(bodyAsBytes, HttpMethod.Post.ToString(),
					requestTimeStamp, Guid.NewGuid().ToString("N"),
					TestSettings.PushUri, TestSettings.WebsiteKey, TestSettings.SecretKey);     


				var authorizationheader = $"hmac {pushSignature}";				// DEZE IS BELANGRIJK: SIGNATURE

				// Function that returns a structured push, based on the JSON pushed that is received.
				var push = pushHandler.DeserializePush(bodyAsBytes, TestSettings.PushUri, authorizationheader);

				var responseData = push.GetActionResponse<IdealPayPush>();

				// 5 example values that can be retrieved from the push. The push contains many more though
				var transactionKey = push.Key;
				var transactionStatus = push.Status;

				var iban = responseData.ConsumerIban;
				var bic = responseData.ConsumerBic;
				var consumerName = responseData.ConsumerName;

				// The following KeyValuePair can be used to update your transaction
				var newTransactionStatus = new KeyValuePair<string, int>(transactionKey, transactionStatus.Code.Code);
			}
		}
	}
}

