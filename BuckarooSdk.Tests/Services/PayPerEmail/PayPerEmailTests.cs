using System;
using BuckarooSdk.Services.PayPerEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Tests.Services.PayPerEmail
{
    [TestClass]
    public class PayPerEmailTests
    {
        private SdkClient _sdkClient;

        [TestInitialize]
        public void Setup()
        {
            this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
        }

        [TestMethod]
        public void PaymentInvitationTest()
        {
            var request = this._sdkClient.CreateRequest()
               .Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("en-US"))
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
               .PaymentInvitation(new PayPerEmailPaymentInvitationRequest()
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
