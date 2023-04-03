using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;

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
                .SetBasicFields(new DataBase() // The transactionBase contains the base information of a transaction.
                {
                    ClientIp = TestSettings.IpAddress,
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })

                .KlarnaKP() // Choose the paymentMethod you want to use
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
                .SetBasicFields(new DataBase() // The transactionBase contains the base information of a transaction.
                {
                    ClientIp = TestSettings.IpAddress,
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })

                .KlarnaKP() // Choose the paymentMethod you want to use
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
                .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
                {
                    Currency = "EUR",
                    AmountDebit = 0.4m,
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })
                .KlarnaKP() // Choose the paymentMethod you want to use
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
                .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
                {
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    OriginalTransactionKey = "12890D0FFE9F4840A69126DA2A93F1B6",
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    AmountCredit = 0.40m,
                })
                .KlarnaKP() // Choose the paymentMethod you want to use
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
                .SetBasicFields(new DataBase() // The transactionBase contains the base information of a transaction.
                {
                    ClientIp = TestSettings.IpAddress,
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                })

                .KlarnaKP() // Choose the paymentMethod you want to use
                .UpdateReservation(Mocks.KlarnaKP.KlarnaKpUpdateReservationMock); // choose the action you want to use and provide the payment method specific info.

            var response = request.Execute();
            var logger = response.BuckarooSdkLogger;

            //Process.Start(response.RequiredAction.RedirectURL);
            Console.WriteLine(logger.GetFullLog());
        }
    }
}