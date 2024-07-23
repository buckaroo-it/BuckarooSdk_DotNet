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
                    CustomerAccountName = "Tester Test",
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
        
        [TestMethod]
        public void PayRecurrentTest()
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
                    OriginalTransactionKey = ""
                })
                .SepaDirectDebit()
                .PayRecurrent(new SepaDirectDebitPayRecurrentRequest()
                {
                    CollectDate = "26-12-2023",
                });

            var paymentResponse = payment.Execute();
        }

        [TestMethod]
        public void PayWithEMandateTest()
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
                .PayWithEMandate(new SepaDirectDebitPayWithEmandateRequest()
                {
                    CollectDate = "26-12-2023",
                    MandateReference = "0Q2D284C4A887F84756A1425A369997xxxx",
                });

            var paymentResponse = payment.Execute();
        }

        [TestMethod]
        public void AuthorizeTest()
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
                .Authorize(new SepaDirectDebitAuthorizeRequest()
                {
                    CustomerAccountName = "Test de Tester",
                    CustomerIban = "NL29RABO8141336991",
                    CustomerBic = "ARBNNL22",
                    MandateReference = "001D284C4A887F84756A1425A369997xxxx",
                    MandateDate = "26-12-2023"
                });

            var paymentResponse = payment.Execute();
        }

        [TestMethod]
        public void ExtraInfoTest()
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
                .PayExtraInfo(new SepaDirectDebitExtraInfoRequest()
                {
                    CustomerAccountName = "John Smith",
                    CustomerIBAN = "NL13TEST0123456789",
                    CustomerBic = "TESTNL2A",
                    MandateReference = "02Q3D175524FCF94C94A23B67E8DCE48E43",
                    MandateDate = "26-12-2023",
                    CustomerCode = "test",
                    CustomerName = "John Smith",
                    CustomerReferencePartyCode = "",
                    CustomerReferencePartyName = "",
                    Street = "Hoofdstraat",
                    HouseNumber = "5",
                    HouseNumberSuffix = "",
                    ZipCode = "844ER",
                    City = "Utrecht",
                    Country = "NL",
                    ContractId = ""
                });

            var paymentResponse = payment.Execute();
        }
    }
}

