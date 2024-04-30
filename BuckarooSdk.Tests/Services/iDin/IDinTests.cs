using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.iDin.TransactionRequest;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.iDin
{
    [TestClass]
    public class IDinTests
    {
        public SdkClient BuckarooClient { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            this.BuckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void IDinIdentifyTest()
        {
            var request =
                this.BuckarooClient.CreateRequest(new StandardLogger())
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                })
                .IDin()
                .Identify(new IDinIdentifyRequest
                {
                    IssuerId = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
                });

            var response = request.Execute();

            Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void IDinVerifyTest()
        {
            var request =
                this.BuckarooClient.CreateRequest(new StandardLogger())
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                })
                .IDin()
                .Verify(new IDinVerifyRequest
                {
                    IssuerId = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
                });

            var response = request.Execute();

            Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestMethod]
        public void IDinLoginTest()
        {
            var request =
                this.BuckarooClient.CreateRequest(new StandardLogger())
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,
                })
                .IDin()
                .Login(new IDinLoginRequest
                {
                    IssuerId = BuckarooSdk.Services.Ideal.Constants.Issuers.IngBank,
                });

            var response = request.Execute();

            Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }
    }
}
