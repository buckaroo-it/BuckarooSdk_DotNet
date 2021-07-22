﻿using System;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.P24.TransactionRequest;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.P24
{
    [TestClass]
    public class P24Tests
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
            var request = this._buckarooClient
                .CreateRequest()
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "PLN",
                    AmountDebit = 0.02m,
                    Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
                    Description = "P24_PAY_SDK_UNITTEST",
                })
                .P24()
                .Pay(new P24PayRequest()
                {
                    CustomerEmail = "s.roos@buckaroo.nl",
                    CustomerFirstName = "Sjaak",
                    CustomerLastName = "Roos"
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
                    OriginalTransactionKey = "FDE0FA2B028F4060BE8A3CDE822D211C",
                    Currency = "PLN",
                    Invoice = "SDK_TEST_636777962968205413",
                    AmountCredit = 0.02m,
                    Description = "P24_REFUND_SDK_UNITTEST",
                })
                .P24()
                .Refund(new P24RefundRequest
                {
                    //set properties
                });

            var response = request.Execute();
        }
    }
}
