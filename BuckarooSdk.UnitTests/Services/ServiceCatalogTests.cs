using System.Globalization;
using System.Linq;
using BuckarooSdk;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Transaction;
using BuckarooSdk.UnitTests.TestSupport;
using Xunit;

namespace BuckarooSdk.UnitTests.Services
{
    /// <summary>
    /// Pins the service code / action / version that each payment method emits onto the request. These
    /// strings are a hard contract with the Buckaroo gateway: a typo (e.g. "Pay" vs "pay") or a wrong
    /// version silently breaks that one payment method in production. Building each method through the
    /// public fluent API and asserting the emitted service turns such a change into a failing test.
    /// </summary>
    public class ServiceCatalogTests
    {
        private static ConfiguredTransaction NewTransaction()
        {
            return new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"))
                .TransactionRequest()
                .SetBasicFields(new TransactionBase
                {
                    Currency = "EUR",
                    AmountDebit = 1.00m,
                    Invoice = "SDK_TEST_CATALOG",
                });
        }

        private static void AssertService(
            ConfiguredServiceTransaction configured, string expectedName, string expectedAction, string expectedVersion)
        {
            var service = configured.BaseTransaction.TransactionBase.Services.ServiceList.Last();
            Assert.Equal(expectedName, service.Name);
            Assert.Equal(expectedAction, service.Action);
            Assert.Equal(expectedVersion, service.Version);
        }

        [Fact]
        public void Ideal_Pay() =>
            AssertService(NewTransaction().Ideal().Pay(new() { Issuer = "INGBNL2A" }), "Ideal", "pay", "2");

        [Fact]
        public void IdealProcessing_Pay() =>
            AssertService(NewTransaction().IdealProcessing().Pay(new()), "Idealprocessing", "pay", "2");

        [Fact]
        public void Giropay_Pay() =>
            AssertService(NewTransaction().Giropay().Pay(new()), "giropay", "Pay", "2");

        [Fact]
        public void Sofort_Pay() =>
            AssertService(NewTransaction().Sofort().Pay(new()), "sofortueberweisung", "Pay", "1");

        [Fact]
        public void PayPal_Pay() =>
            AssertService(NewTransaction().PayPal().Pay(new()), "PayPal", "pay", "1");

        [Fact]
        public void Transfer_Pay() =>
            AssertService(NewTransaction().Transfer().Pay(new()), "Transfer", "pay", "1");

        [Fact]
        public void Eps_Pay() =>
            AssertService(NewTransaction().EPS().Pay(new()), "eps", "Pay", "1");

        [Fact]
        public void P24_Pay() =>
            AssertService(NewTransaction().P24().Pay(new()), "Przelewy24", "pay", "1");

        [Fact]
        public void SepaDirectDebit_Pay() =>
            AssertService(NewTransaction().SepaDirectDebit().Pay(new()), "SepaDirectDebit", "pay", "1");

        [Fact]
        public void SimpleSepaDirectDebit_Pay() =>
            AssertService(NewTransaction().SimpleSepaDirectDebit().Pay(new()), "SimpleSepaDirectDebit", "pay", "2");

        [Fact]
        public void Multibanco_Pay() =>
            AssertService(NewTransaction().Multibanco().Pay(new()), "Multibanco", "pay", "0");

        [Fact]
        public void MBWay_Pay() =>
            AssertService(NewTransaction().MBWay().Pay(new()), "MBWay", "pay", "0");

        [Fact]
        public void PaymentInitiation_Pay() =>
            AssertService(NewTransaction().PaymentInitiation().Pay(new()), "PayByBank", "pay", "0");

        [Fact]
        public void Bancontact_Pay() =>
            AssertService(NewTransaction().Bancontact().Pay(new()), "bancontactmrcash", "Pay", "1");

        // Non-Pay actions carry their own action string + version — just as much a gateway contract as Pay.

        [Fact]
        public void Ideal_Refund() =>
            AssertService(NewTransaction().Ideal().Refund(new()), "Ideal", "refund", "2");

        [Fact]
        public void Ideal_PayRemainder() =>
            AssertService(NewTransaction().Ideal().PayRemainder(new() { Issuer = "INGBNL2A" }), "Ideal", "payremainder", "2");

        [Fact]
        public void Ideal_PayFastCheckout() =>
            AssertService(NewTransaction().Ideal().PayFastCheckout(new()), "Ideal", "PayFastCheckout", "2");

        [Fact]
        public void Sofort_Refund() =>
            AssertService(NewTransaction().Sofort().Refund(new()), "sofortueberweisung", "Refund", "1");

        [Fact]
        public void Giropay_Refund() =>
            AssertService(NewTransaction().Giropay().Refund(new()), "giropay", "Refund", "2");
    }
}
