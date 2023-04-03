using BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.CreditManagement.DataRequest;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.CreditManagement
{
    [TestClass]
    public class CreditManagementTests
    {
        private SdkClient _sdkClient;

        [TestInitialize]
        public void Setup()
        {
            this._sdkClient = new SdkClient(TestSettings.Logger);
        }

        [TestMethod]
        public void CreateInvoice()
        {
            var dataRequest = this._sdkClient.CreateRequest()
            .Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, CultureInfo.GetCultureInfo("nl-NL"))
            .DataRequest()
            .SetBasicFields(new DataBase
            {
                Currency = "EUR",
                Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
                Description = "CM3_CREATEINVOICE_SDK_TEST",
                ReturnUrl = TestSettings.ReturnUrl,
                ReturnUrlCancel = TestSettings.ReturnUrlCancel,
                ReturnUrlError = TestSettings.ReturnUrlError,
                ReturnUrlReject = TestSettings.ReturnUrlReject,
            })
            .CreditManagement()
            .CreateInvoice(new CreditManagementCreateInvoiceRequest
            {
                InvoiceDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(5),
                SchemeKey = "99wofp",
                InvoiceAmount = 60.00m,
                Debtor = new Debtor
                {
                    Code = "20161124",
                },
                Person = new Person
                {
                    Initials = "JJA",
                    FirstName = "Sjaak",
                    LastName = "Roos",
                    Gender = BuckarooSdk.Services.CreditManagement.Constants.Gender.Male,
                    Culture = "nl-NL",
                },
                Address = new Address
                {
                    Street = "Zonnebaan",
                    HouseNumber = "9",
                    ZipCode = "3542 EA",
                    City = "Utrecht",
                    Country = "NL",
                },
                Email = new EmailAddress
                {
                    Email = "techsup@buckaroo.nl",
                },
                Phone = new Phone
                {
                    Mobile = "0600000000",
                },
            });

            var requestResponse = dataRequest.Execute();

            //var logging = this._sdkClient.LoggerFactory.GetFullLog();
            //Console.WriteLine(logging);
        }
    }
}
