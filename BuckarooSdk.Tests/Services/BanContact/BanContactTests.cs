using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.CreditCards.BanContact.Request;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Bancontact
{
    [TestClass]
    public class BancontactTests
    {
        private SdkClient _buckarooClient;
        private string TestName => nameof(BancontactTests).ToUpper();

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
                .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
                {
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    AmountDebit = 2,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .Bancontact() // Choose the paymentMethod you want to use
                .Pay(new BancontactPayRequest // choose the action you want to use and provide the payment method specific info.
                {

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
                .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
                {
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    OriginalTransactionKey = "",
                    AmountCredit = 2,
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .Bancontact() // Choose the paymentMethod you want to use
                .Refund(new BancontactRefundRequest // choose the action you want to use and provide the payment method specific info.
                {
                    CustomerIBAN = string.Empty,
                    CustomerAccountName = string.Empty,
                    CustomerBIC = string.Empty,

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
                .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
                {
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    AmountDebit = 2,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    OriginalTransactionKey = "",
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .Bancontact() // Choose the paymentMethod you want to use
                .PayRemainder(new BancontactPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }
        [TestMethod]
        public void PayEncryptedTest()
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
                    AmountDebit = 2,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .Bancontact() // Choose the paymentMethod you want to use
                .PayEncrypted(new BancontactPayEncryptedRequest // choose the action you want to use and provide the payment method specific info.
                {
                    EncryptedCardData = string.Empty,
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


