using System.Globalization;
using System.Linq;
using BuckarooSdk;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.Transaction;
using BuckarooSdk.UnitTests.TestSupport;
using Xunit;

namespace BuckarooSdk.UnitTests.Transaction
{
    /// <summary>
    /// Asserts on the object graph the fluent API assembles before it is serialized and sent. Reaching
    /// the internal <c>Request</c>/<c>TransactionBase</c> members (via InternalsVisibleTo) proves the
    /// builder wires up authentication, the endpoint and the service list correctly — the logic most
    /// likely to change when new payment methods or actions are added.
    /// </summary>
    public class FluentBuilderTests
    {
        private static ConfiguredServiceTransaction BuildIdealPay()
        {
            return new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"), ChannelEnum.Web)
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 0.02m,
                    Invoice = "SDK_TEST_0001",
                    Description = "Unit test transaction",
                })
                .Ideal()
                .Pay(new IdealPayRequest { Issuer = "INGBNL2A" });
        }

        [Fact]
        public void Authenticate_StoresCredentialsAndContextOnRequest()
        {
            var request = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, isLive: false,
                    new CultureInfo("nl-NL"), ChannelEnum.Web)
                .TransactionRequest();

            var underlying = request.AuthenticatedRequest.Request;
            Assert.Equal(TestCredentials.WebsiteKey, underlying.WebsiteKey);
            Assert.Equal(TestCredentials.ApiKey, underlying.ApiKey);
            Assert.False(underlying.IsLive);
            Assert.Equal("nl-NL", underlying.Culture.Name);
            Assert.Equal(ChannelEnum.Web, underlying.Channel);
        }

        [Fact]
        public void TransactionRequest_SetsTransactionEndpoint()
        {
            var request = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest();

            // Assert the literal wire path, not the SDK's own constant — comparing the constant to itself
            // would still pass if the constant were changed to a wrong path.
            Assert.Equal("/json/transaction", request.AuthenticatedRequest.Request.Endpoint);
        }

        [Fact]
        public void Ideal_Pay_AddsSingleIdealServiceWithActionAndVersion()
        {
            var body = BuildIdealPay().BaseTransaction.TransactionBase;

            var service = Assert.Single(body.Services.ServiceList);
            Assert.Equal("Ideal", service.Name);
            Assert.Equal("pay", service.Action);
            Assert.Equal("2", service.Version);
        }

        [Fact]
        public void Ideal_Pay_MapsIssuerIntoServiceParameters()
        {
            var body = BuildIdealPay().BaseTransaction.TransactionBase;

            var parameter = Assert.Single(body.Services.ServiceList.Single().Parameters);
            Assert.Equal("Issuer", parameter.Name);
            Assert.Equal("INGBNL2A", parameter.Value);
        }

        [Fact]
        public void SetBasicFields_PreservesTransactionBaseValues()
        {
            var body = BuildIdealPay().BaseTransaction.TransactionBase;

            Assert.Equal("EUR", body.Currency);
            Assert.Equal(0.02m, body.AmountDebit);
            Assert.Equal("SDK_TEST_0001", body.Invoice);
        }

        [Fact]
        public void AddCustomParameter_AppendsToCustomParameterList()
        {
            var basicFields = new TransactionBase
            {
                Currency = "EUR",
                AmountDebit = 1.00m,
                Invoice = "SDK_TEST_0002",
            };
            basicFields.AddCustomParameter("MyField", "MyValue");

            var configured = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(basicFields)
                .Ideal()
                .Pay(new IdealPayRequest { Issuer = "INGBNL2A" });

            var custom = Assert.Single(configured.BaseTransaction.TransactionBase.CustomParameters.List);
            Assert.Equal("MyField", custom.Name);
            Assert.Equal("MyValue", custom.Value);
        }

        [Fact]
        public void AddAdditionalService_AppendsSecondServiceToSameRequest()
        {
            // Combined-invoice / credit-management flows attach a second service to one transaction.
            var configured = BuildIdealPay()
                .AddAdditionalService()
                .CreditManagement()
                .CreateCombinedInvoice(new());

            var services = configured.BaseTransaction.TransactionBase.Services.ServiceList;
            Assert.Equal(2, services.Count);
            Assert.Equal("Ideal", services[0].Name);
            Assert.Equal("CreditManagement3", services[1].Name);
            Assert.Equal("CreateCombinedInvoice", services[1].Action);
            Assert.Equal("1", services[1].Version);
        }
    }
}
