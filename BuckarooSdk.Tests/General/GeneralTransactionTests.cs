using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.General
{
	[TestClass]
	public class GeneralTransactionTests
	{
		private SdkClient SdkClient { get;set; }

		public GeneralTransactionTests()
		{
			this.SdkClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void TransactionSpecificationTest()
		{
			var request = this.SdkClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionSpecificationRequest()
				.SpecificServiceSpecification("ideal", 2);

			var response = request.GetMultipleSpecificiations();
		}

		[TestMethod]
		public void MultipleSpecificationTest()
		{
			var request = this.SdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionSpecificationRequest()
				.MultipleServiceSpecifications(new TransactionSpecificationBase()
						.AddService("ideal", 2)
						.AddService("transfer")
						.AddService("paypal")
				);

			var response = request.GetMultipleSpecificiations();
			
			Assert.AreEqual(3, response.Services.Count);
		}

		[TestMethod]
		public void NoServiceTransactionTest()
		{
			var request = this.SdkClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase // The transactionbase contains the base information of a transaction.
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "NOSERVICESELECTED_PAY_SDK_UNITTEST",
					ReturnUrl = TestSettings.ReturnUrl,
					ReturnUrlCancel = TestSettings.ReturnUrlCancel,
					ReturnUrlError = TestSettings.ReturnUrlError,
					ReturnUrlReject = TestSettings.ReturnUrlReject,
					ContinueOnIncomplete = ContinueOnIncomplete.RedirectToHTML,
				})
				;
				
			var response = request.ExecuteWithoutSelectedService();

		}
		[TestMethod]
		public void CancelTransactionTest()
		{
			IEnumerable<string> transactionsToBeCanceled = new List<string>()
			{
				"94436C07DE6F44EBACBF26CB561F17B3",
			};
			var request = this.SdkClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.CancelTransactionRequest()
				.CancelMultiple(new CancelTransactionBase(transactionsToBeCanceled));

			var response = request.Execute();

		}

		[TestMethod]
		public void TransactionStatusTest()
		{
			const string key = "F7465FEA423A4374997C652DDA6BE35A";

			var request = this.SdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionStatusRequest()
				.Status(key);

			var requestResponse = request.GetSingleStatus();

			if (requestResponse.Status.Code.Code == BuckarooSdk.Constants.Status.WaitingForConsumer)
			{
				Process.Start("");

			}
			if (requestResponse.Status.Code.Code == BuckarooSdk.Constants.Status.Success)
			{

			}

			//var logging = this.SdkClient.LoggerFactory.GetFullLog();
			//Console.WriteLine(logging);

		}

		[TestMethod]
		public void InvoiceInfoTest()
		{

			const string transactionKey = "244BD8425FB941B7B93E70F5AED31F3A";

			var request = this.SdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionInvoiceInfoRequest()
				.SpecificInvoiceInfo(transactionKey);

			var response = request.GetSingleInvoiceInfoRequest();

		}

		[TestMethod]
		public void InvoicesInfoTest()
		{
			var request = this.SdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionInvoiceInfoRequest()
				.MultipleInvoicesInfo(new TransactionInvoiceInfoBase()
				{
					InvoiceCollection = new List<InvoiceInfoRequestInvoice>()
					{
						new InvoiceInfoRequestInvoice()
						{
							Key = "",
							CustomerId = "",
							Number = ""
						}
					}
				});

			var response = request.GetMultipleInvoiceInfoRequest();
		}

		[TestMethod]
		public void RefundInfoTest()
		{
			const string transactionKey = "8CC823FB3A9545B99608541DF4BC4DFF";

			var request = this.SdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRefundInfoRequest()
				.SpecificConfiguredTransactionRefundInfo(transactionKey);


			var response = request.GetSingleRefundInfo();


			Console.WriteLine();
		}

		[TestMethod]
		public void RefundsInfoTest()
		{
			var transactionKeyList = new List<string>()
			{
				"fasdfasdhgffgdhfasdwer",
				"asdfasdffhgdtrwerasfda",
				"fdaswerqrgtdgfsasdffwe",
			};

			var request = this.SdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRefundInfoRequest()
				.MultipleConfiguredTransactionRefundInfo(new TransactionRefundInfoBase(transactionKeyList));

			var response = request.GetMultipleRefundsInfo();
		}
	}
}
