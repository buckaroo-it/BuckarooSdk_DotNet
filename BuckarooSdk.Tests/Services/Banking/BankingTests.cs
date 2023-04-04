using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.Banking;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Banking
{
    [TestClass]
    public class BankingTests
    {
        private SdkClient _buckarooClient;
        private string TestName => nameof(BankingTests).ToUpper();

        [TestInitialize]
        public void Setup()
        {
            this._buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void BankingPaymentOrderTest()
        {
            var request =
            this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
            .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
            .TransactionRequest() // One of the request type options.
            .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
            {

                Currency = "EUR",
                Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                ReturnUrl = TestSettings.ReturnUrl,
                ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                ReturnUrlError = TestSettings.ReturnUrlError,
                ReturnUrlReject = TestSettings.ReturnUrlReject,
            })
            .Banking() // Choose the paymentMethod you want to use
            .PaymentOrder(new BankingPaymentOrderRequest
            {
                StructuredIssuerType = string.Empty,
                ProcessingDate = DateTime.MinValue,
                Purpose = string.Empty,
                IBAN = string.Empty,
                BIC = string.Empty,
                StructuredReference = string.Empty,
                AccountHolderName = string.Empty,
            });

            var response = request.Execute();
            // Process.Start(response.RequiredAction.RedirectURL);
            Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void BankingInstantPaymentOrderTest()
        {
            var request =
            this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
            .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
            .TransactionRequest() // One of the request type options.
            .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
            {

                Currency = "EUR",
                Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                ReturnUrl = TestSettings.ReturnUrl,
                ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                ReturnUrlError = TestSettings.ReturnUrlError,
                ReturnUrlReject = TestSettings.ReturnUrlReject,
            })
            .Banking() // Choose the paymentMethod you want to use
            .InstantPaymentOrder(new BankingInstantPaymentOrderRequest
            {
            });

            var response = request.Execute();
            // Process.Start(response.RequiredAction.RedirectURL);
            Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestCleanup]
        public void TearDown()
        {
            this._buckarooClient = null;
        }
    }
}
