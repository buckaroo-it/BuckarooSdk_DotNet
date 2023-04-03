using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.CreditCards.MasterCard.Request;
using BuckarooSdk.Services.CreditCards.Request;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.MasterCard
{
    [TestClass]
    public class MasterCardTests
    {
        private SdkClient _buckarooClient;
        private string TestName => nameof(MasterCardTests).ToUpper();

        [TestInitialize]
        public void Setup()
        {
            this._buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        [Obsolete]
        public void PayTest()
        {
            var request = this._buckarooClient.CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    Description = $"{TestName}_SDK_UNITTEST",
                })
                .MasterCard()
                .Pay(new MasterCardPayRequest()
                {
                    //set properties
                });

            var response = request.Execute();
        }

        [TestMethod]
        [Obsolete]
        public void RefundTest()
        {
            var request = this._buckarooClient.CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountCredit = 0.02m,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    OriginalTransactionKey = "59915ADC227149F4A3ACE9E0C8589D3C",
                    Description = $"{TestName}_SDK_UNITTEST",
                })
                .MasterCard()
                .Refund(new MasterCardRefundRequest()
                {
                    //set properties
                });
            var response = request.Execute();
        }

        [TestMethod]
        [Obsolete]
        public void AuthorizeTest()
        {
            var request = this._buckarooClient.CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    Description = $"{TestName}_SDK_UNITTEST",

                })
                .MasterCard()
                .Authorize(new MasterCardAuthorizeRequest()
                {
                    //set properties
                });

            var response = request.Execute();
        }

        [TestMethod]
        [Obsolete]
        public void CaptureTest()
        {
            var request = this._buckarooClient.CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .MasterCard()
                .Capture(new MasterCardCaptureRequest()
                {
                    //set properties
                });

            var response = request.Execute();
        }

        [TestMethod]
        [Obsolete]
        public void PayRecurrentTest()
        {
            var request = this._buckarooClient.CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .MasterCard()
                .PayRecurrent(new MasterCardPayRecurrentRequest()
                {
                    //define properties
                });
            var response = request.Execute();
        }

        [TestMethod]
        [Obsolete]
        public void PayRemainderTest()
        {
            var request = this._buckarooClient.CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .MasterCard()
                .PayRemainder(new MasterCardPayRemainderRequest()
                {
                    //define properties
                });

            var response = request.Execute();
        }

        [TestMethod]
        public void CancelAuthorizeTest()
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
                    .MasterCard() // Choose the paymentMethod you want to use
                    .CancelAuthorize(new MasterCardCancelAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
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
                .MasterCard() // Choose the paymentMethod you want to use
                .PayEncrypted(new MasterCardPayEncryptedRequest // choose the action you want to use and provide the payment method specific info.
                {
                    EncryptedCardData = string.Empty,

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void AuthorizeEncryptedTest()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .AuthorizeEncrypted(new MasterCardAuthorizeEncryptedRequest // choose the action you want to use and provide the payment method specific info.
                {
                    EncryptedCardData = string.Empty,

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void PayTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .Pay(new CreditCardPayRequest // choose the action you want to use and provide the payment method specific info.
                {
                    CustomerCode = string.Empty,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void RefundTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .Refund(new CreditCardRefundRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void AuthorizeTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .Authorize(new CreditCardAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
                {
                    CustomerCode = string.Empty,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void CaptureTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .Capture(new CreditCardCaptureRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void CancelAuthorizeTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .CancelAuthorize(new CreditCardCancelAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void PayRecurrentTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .PayRecurrent(new CreditCardPayRecurrentRequest // choose the action you want to use and provide the payment method specific info.
                {

                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void PayRemainderTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .PayRemainder(new CreditCardPayRemainderRequest // choose the action you want to use and provide the payment method specific info.
                {
                    CustomerCode = string.Empty,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void PayEncryptedTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .PayEncrypted(new CreditCardPayEncryptedRequest // choose the action you want to use and provide the payment method specific info.
                {
                    EncryptedCardData = string.Empty,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void AuthorizeEncryptedTestCreditCard()
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
                .MasterCard() // Choose the paymentMethod you want to use
                .AuthorizeEncrypted(new CreditCardAuthorizeEncryptedRequest // choose the action you want to use and provide the payment method specific info.
                {
                    EncryptedCardData = string.Empty,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }
    }
}
