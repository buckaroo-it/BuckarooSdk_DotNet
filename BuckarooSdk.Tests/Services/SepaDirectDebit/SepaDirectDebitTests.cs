using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.SepaDirectDebit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.SepaDirectDebit
{
    [TestClass]
    public class SepaDirectDebitTests
    {
        private SdkClient _sdkClient;

        [TestInitialize]
        public void Setup()
        {
            this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
        }

        [TestMethod]
        public void PayTest()
        {
            var payment = this._sdkClient.CreateRequest()
                .Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
                    Description = "SEPADIRECTDEBIT_PAY_SDK_UNITTEST",
                    StartRecurrent = true,

                })
                .SepaDirectDebit()
                .Pay(new SepaDirectDebitPayRequest()
                {
                    MandateReference = "0012652668455265",
                    MandateDate = "16-12-2023",
                    CustomerBic = "INGBNL2A",
                    CustomerAccountName = "JJA Roos",
                    CollectDate = "26-12-2023",
                });

            var paymentResponse = payment.Execute();
        }

        [TestMethod]
        public void RefundTest()
        {
            var request = this._sdkClient.CreateRequest()
                .Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    AmountCredit = 0.02m,
                    Currency = "EUR",
                    Invoice = "",
                    OriginalTransactionKey = "",
                    Description = "SEPADIRECTDEBIT_REFUND_SDK_UNITTEST",

                })
                .SepaDirectDebit()
                .Refund(new SepaDirectDebitRefundRequest()
                {
                });

            var response = request.Execute();
        }
    }
}

