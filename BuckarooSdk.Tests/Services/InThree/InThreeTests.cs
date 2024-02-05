using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;


namespace BuckarooSdk.Tests.Services.InThree
{
    [TestClass]
    public class InThreeTests
    {
        private SdkClient _buckarooClient;
        private string TestName => nameof(InThreeTests).ToUpper();

        [TestInitialize]
        public void Setup()
        {
            this._buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void PayTest()
        {
            var payment =
                this._buckarooClient.CreateRequest(new StandardLogger())
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                    AmountDebit = 0.02M,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
                    Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ClientIp = TestSettings.IpAddress,
                })
                .InThree()
                .Pay(Mocks.InThree.InThreePayMock);

            var paymentResponse = payment.Execute();
        }

        [TestMethod]
        public void RefundTest()
        {
            var request =
                this._buckarooClient.CreateRequest(new StandardLogger())
                    .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                    .TransactionRequest()
                    .SetBasicFields(new TransactionBase
                    {
                        Currency = "EUR",
                        Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                        ReturnUrl = TestSettings.ReturnUrl,
                        ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                        ReturnUrlError = TestSettings.ReturnUrlError,
                        ReturnUrlReject = TestSettings.ReturnUrlReject,
                        Invoice = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                        OriginalTransactionKey = "",
                        AmountCredit = 0.02M,
                        Order = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                        ClientIp = TestSettings.IpAddress,
                    })
                    .InThree()
                    .Refund(Mocks.InThree.InThreeRefundMock());

            var response = request.Execute();
        }

    }
}
