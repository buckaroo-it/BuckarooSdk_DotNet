using System;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.SimpleSepaDirectDebit;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.SimpleSepaDirectDebit
{
    [TestClass]
    public class SimpleSepaDirectDebitTests
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
            var payment = _buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
                    Description = "SIMPLESEPADIRECTDEBIT_PAY_SDK_UNITTEST",
                    StartRecurrent = true,

                })
                .SimpleSepaDirectDebit()
                .Pay(new SimpleSepaDirectDebitPayRequest
                {
                    MandateReference = "0012652668455265",
                    MandateDate = "16-11-2016",
                    CustomerIban = "NL88INGB0757641768",
                    CustomerBic = "INGBNL2A",
                    CustomerAccountName = "JJA Roos",
                    CollectDate = "26-11-2016",
                });

            var paymentResponse = payment.Execute();
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
                    AmountCredit = 0.02m,
                    Currency = "EUR",
                    Invoice = "",
                    OriginalTransactionKey = "",
                    Description = "SIMPLESEPADIRECTDEBIT_REFUND_SDK_UNITTEST",

                })
                .SimpleSepaDirectDebit()
                .Refund(new SimpleSepaDirectDebitRefundRequest
                {
                    CustomerIban = "NL88INGB0757641768",
                    CustomerBic = "INGBNL2A",
                    CustomerAccountName = "JJA Roos",
                });

            var response = request.Execute();
        }
    }
}
