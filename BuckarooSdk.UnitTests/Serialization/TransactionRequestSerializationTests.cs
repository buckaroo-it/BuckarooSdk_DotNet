using System.Globalization;
using BuckarooSdk;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.Transaction;
using BuckarooSdk.UnitTests.TestSupport;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BuckarooSdk.UnitTests.Serialization
{
    /// <summary>
    /// Serializes the assembled request body with the exact settings the SDK's <c>Connector</c> uses,
    /// so these tests assert on the precise JSON that would be POSTed to Buckaroo — the camelCase
    /// property names and the nested <c>services.serviceList</c> shape the gateway requires — without
    /// performing any request.
    /// </summary>
    public class TransactionRequestSerializationTests
    {
        private static TransactionBase BuildIdealPayBody()
        {
            var configured = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"))
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

            return configured.BaseTransaction.TransactionBase;
        }

        [Fact]
        public void Serialize_UsesCamelCaseTopLevelProperties()
        {
            var json = BuckarooJson.SerializeToObject(BuildIdealPayBody());

            Assert.Equal("EUR", (string)json["currency"]);
            Assert.Equal(0.02m, (decimal)json["amountDebit"]);
            Assert.Equal("SDK_TEST_0001", (string)json["invoice"]);
            Assert.Equal("Unit test transaction", (string)json["description"]);
        }

        [Fact]
        public void Serialize_NestsServicesUnderServiceList()
        {
            var json = BuckarooJson.SerializeToObject(BuildIdealPayBody());

            var serviceList = (JArray)json["services"]["serviceList"];
            var service = Assert.Single(serviceList);
            Assert.Equal("Ideal", (string)service["name"]);
            Assert.Equal("pay", (string)service["action"]);
            Assert.Equal("2", (string)service["version"]);
        }

        [Fact]
        public void Serialize_IncludesServiceParameterNameAndValue()
        {
            var json = BuckarooJson.SerializeToObject(BuildIdealPayBody());

            var parameters = (JArray)json["services"]["serviceList"][0]["parameters"];
            var parameter = Assert.Single(parameters);
            Assert.Equal("Issuer", (string)parameter["name"]);
            Assert.Equal("INGBNL2A", (string)parameter["value"]);
        }

        [Fact]
        public void Serialize_DecimalAmount_ParsesBackTo0_02_UnderCommaCulture()
        {
            // Under a comma-decimal locale the emitted JSON must still parse as the numeric 0.02 (a comma
            // would produce invalid JSON / a different value). Asserting the parsed JToken — rather than a
            // raw substring — avoids coupling to Newtonsoft's indentation and reads the actual value.
            var original = System.Threading.Thread.CurrentThread.CurrentCulture;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
                var json = BuckarooJson.SerializeToObject(BuildIdealPayBody());

                Assert.Equal(0.02m, (decimal)json["amountDebit"]);
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = original;
            }
        }

        [Fact]
        public void Serialize_CustomAndAdditionalParameters_ProduceLegacyListShapes()
        {
            var basicFields = new TransactionBase
            {
                Currency = "EUR",
                AmountDebit = 1.00m,
                Invoice = "SDK_TEST_PARAMS",
            };
            basicFields.AddCustomParameter("MyCustom", "CustomValue");
            basicFields.AddAdditionalParameter("MyAdditional", "AdditionalValue");

            var configured = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(basicFields)
                .Ideal()
                .Pay(new() { Issuer = "INGBNL2A" });

            var json = BuckarooJson.SerializeToObject(configured.BaseTransaction.TransactionBase);

            var custom = Assert.Single((JArray)json["customParameters"]["list"]);
            Assert.Equal("MyCustom", (string)custom["name"]);
            Assert.Equal("CustomValue", (string)custom["value"]);

            var additional = Assert.Single((JArray)json["additionalParameters"]["additionalParameter"]);
            Assert.Equal("MyAdditional", (string)additional["name"]);
            Assert.Equal("AdditionalValue", (string)additional["value"]);
        }
    }
}
