using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.Notification;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Notification
{
    [TestClass]
    public class NotificationTests
    {
        private SdkClient _buckarooClient;
        private string TestName => nameof(NotificationTests).ToUpper();

        [TestInitialize]
        public void Setup()
        {
            this._buckarooClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void ExtraInfoTest()
        {
            var request =
                this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
                .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest() // One of the request type options.
                .SetBasicFields(new TransactionBase // The transactionBase contains the base information of a transaction.
                {
                    Currency = "EUR",
                    Description = $"SDK_{TestName}_{DateTime.Now.Ticks}",
                    ReturnUrl = TestSettings.ReturnUrl,
                    ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                    ReturnUrlError = TestSettings.ReturnUrlError,
                    ReturnUrlReject = TestSettings.ReturnUrlReject,

                })
                .Notification() // Choose the paymentMethod you want to use
                .ExtraInfo(new NotificationExtraInfoRequest // choose the action you want to use and provide the payment method specific info.
                {
                    SendDatetime = DateTime.MinValue,
                    NotificationType = string.Empty, // Mandatory
                    RecipientLastName = string.Empty,
                    RecipientGender = string.Empty,
                    CommunicationMethod = string.Empty, // Mandatory
                    RecipientEmail = string.Empty, // Mandatory
                    Attachment = string.Empty,
                    RecipientFirstName = string.Empty,
                });

            var response = request.Execute();

            // Process.Start(response.RequiredAction.RedirectURL);
            // Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
        }

        [TestCleanup]
        public void TearDown()
        {
            this._buckarooClient = null;
        }
    }
}