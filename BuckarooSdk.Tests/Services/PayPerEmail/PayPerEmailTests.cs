using System;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.PayPerEmail;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.PayPerEmail
{
    [TestClass]
    public class PayPerEmailTests
    {
        private SdkClient _buckarooClient;

        [TestInitialize]
        public void Setup()
        {
            _buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void PaymentInvitationTest()
        {
            var request = _buckarooClient
                .CreateRequest()
               .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("en-US"))
               .TransactionRequest()
               .SetBasicFields(new TransactionBase
               {
                   Currency = "EUR",
                   AmountDebit = 75.00m,
                   Invoice = $"INV_{DateTime.Now.Ticks}",
                   Description = "SDK_TEST",
                   ServicesSelectableByClient = "ideal",
               })
               .PayPerEmail()
               .PaymentInvitation(new PayPerEmailPaymentInvitationRequest
               {
                   CustomerGender = BuckarooSdk.Services.PayPerEmail.Constants.Gender.Male,
                   Attachment = "",
                   MerchantSendsEmail = false,
                   ExpirationDate = null,
                   PaymentMethodsAllowed = "ideal",
                   CustomerEmail = "techsup@buckaroo.nl",
                   CustomerFirstName = "Sjaak",
                   CustomerLastName = "Roos",
               });

            var paypermailResponse = request.Execute();
            var actionResponse = paypermailResponse.GetActionResponse<PayPerEmailPaymentInvitationResponse>();
        }
    }
}
