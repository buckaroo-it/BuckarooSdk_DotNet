using System;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.PayPal;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.PayPal
{
    [TestClass]
    public class PayPalTests
    {
        private SdkClient _buckarooClient;

        [TestInitialize]
        public void Setup()
        {
            _buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void PayTest()
        {
            var request = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
                    Description = "PAYPAL_PAY_SDK_UNITTEST",
                })
                .PayPal()
                .Pay(new PayPalPayRequest()
                {
                    //define properties
                    BuyerEmail = "techsup@buckaroo.nl",
                    ProductName = "haardhout",
                });

            var paymentResponse = request.Execute();
        }

        [TestMethod]
        [Obsolete]
        public void RefundTest_Obsolete()
        {
            var request = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
                })
                .PayPal()
                .Refund(new PayPalRefundRequest()
                {
                    //define properties

                });

            var response = request.Execute();
        }

        [TestMethod]
        public void RefundTest()
        {
            var request = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
                })
                .PayPal()
                .Refund();

            var response = request.Execute();
        }

        [TestMethod]
        public void PayRecurrentTest()
        {
            var request = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
                })
                .PayPal()
                .PayRecurrent(new PayPalPayRecurrentRequest()
                {
                    //define properties

                });
            
            var response = request.Execute();
        }

        [TestMethod]
        [Ignore]
        public void PayRemainderTest()
        {
            var request = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
                })
                .PayPal()
                .PayRemainder(new PayPalPayRemainderRequest
                {
                    //define properties
                    BuyerEmail = "techsup@buckaroo.nl",

                });

            var response = request.Execute();
        }

        [TestMethod]
        public void ExtraInfoTest()
        {
            var request = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}"
                })
                .PayPal()
                .ExtraInfo(new PayPalExtraInfoRequest
                {
                    //define properties
                });
            
            var response = request.Execute();
        }
    }
}
