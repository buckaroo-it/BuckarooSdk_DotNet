using System;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.Sofort;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.Sofort
{
    [TestClass]
    public class SofortTests
    {
        private SdkClient _buckarooClient;

        private string TestName => nameof(SofortTests).ToUpper();

        [TestInitialize]
        public void Setup()
        {
            _buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void PayTest()
        {
            var request = _buckarooClient
                .CreateRequest(new StandardLogger()) // Create a request.
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
                .Sofort() // Choose the paymentmethod you want to use
                .Pay(new SofortPayRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }
        
        [TestMethod]
        public void RefundTest()
        {
            var request = _buckarooClient
                .CreateRequest(new StandardLogger()) // Create a request.
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
                .Sofort() // Choose the paymentmethod you want to use
                .Refund(new SofortRefundRequest // choose the action you want to use and provide the payment method specific info.
                {
                    CustomerBIC = string.Empty,
                    CustomerIBAN = string.Empty,
                    CustomerAccountName = string.Empty,
                    CustomerKontoNummer = 0,
                    CustomerBankLeitzahl = 0,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void PayRemainderTest()
        {
            var request = _buckarooClient
                .CreateRequest(new StandardLogger()) // Create a request.
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
                .Sofort() // Choose the paymentmethod you want to use
                .PayRemainder(new SofortPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestCleanup]
        public void TearDown()
        {
            _buckarooClient = null;
        }
    }
}


