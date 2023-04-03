using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.CreditCards.Request;
using BuckarooSdk.Services.CreditCards.Visa.Request;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Visa
{
    [TestClass]
    public class VisaTests
    {
        private SdkClient _buckarooClient;
        private string TestName => nameof(VisaTests).ToUpper();

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
                    Invoice = $"SDK_{TestName}_ {DateTime.Now.Ticks}"
                }
                    .AddAdditionalParameter("add_test1", DateTime.Now.Ticks.ToString())
                    .AddAdditionalParameter("add_test2", "test")
                )
                .Visa()
                .Pay(new VisaPayRequest()
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
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_{TestName}_ {DateTime.Now.Ticks}"
                })
                .Visa()
                .Refund(new VisaRefundRequest()
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
                    Invoice = $"SDK_{TestName}_ {DateTime.Now.Ticks}"
                }
                    .AddAdditionalParameter("add_test1", DateTime.Now.Ticks.ToString())
                    .AddAdditionalParameter("add_test2", "test")
                )
                .Visa()

                .Authorize(new VisaAuthorizeRequest()
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
                    Invoice = $"SDK_{TestName}_ {DateTime.Now.Ticks}"
                })
                .Visa()

                .Capture(new VisaCaptureRequest()
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
                    Invoice = $"SDK_{TestName}_ {DateTime.Now.Ticks}"
                })
                .Visa()

                .PayRecurrent(new VisaPayRecurrentRequest()
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
                    Invoice = $"SDK_{TestName}_ {DateTime.Now.Ticks}"
                })
                .Visa()

                .PayRemainder(new VisaPayRemainderRequest()
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
                    .Visa() // Choose the paymentMethod you want to use
                    .CancelAuthorize(new VisaCancelAuthorizeRequest // choose the action you want to use and provide the payment method specific info.
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
                .Visa() // Choose the paymentMethod you want to use
                .PayEncrypted(new VisaPayEncryptedRequest // choose the action you want to use and provide the payment method specific info.
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
                .Visa() // Choose the paymentMethod you want to use
                .AuthorizeEncrypted(new VisaAuthorizeEncryptedRequest // choose the action you want to use and provide the payment method specific info.
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
                .Visa() // Choose the paymentMethod you want to use
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
