using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using BuckarooSdk.Services;
using Xunit;

namespace BuckarooSdk.UnitTests.Services
{
    /// <summary>
    /// <c>ServiceHelper</c> is the reflection engine that flattens every strongly-typed service request
    /// (iDEAL, Afterpay, Klarna, ...) into the flat name/value/group parameter list Buckaroo expects.
    /// It is driven here with minimal test doubles built from the SDK's own public parameter-group
    /// abstractions, so each branch (simple / group / indexed collection / enumerable) is covered without
    /// coupling to any single payment method.
    /// </summary>
    public class ServiceHelperTests
    {
        private sealed class SimpleRequest
        {
            public string Issuer { get; set; }
            public string Empty { get; set; }
        }

        private sealed class AmountRequest
        {
            public decimal Amount { get; set; }
        }

        private sealed class CardRequest
        {
            public string CreditcardNumber { get; set; }
        }

        private sealed class Address : ParameterGroup
        {
            public string City { get; set; }
        }

        private sealed class GroupRequest
        {
            public Address BillingAddress { get; set; }
        }

        private sealed class ArticleCollectionRequest
        {
            public ParameterGroupCollection<Address> Articles { get; set; }
        }

        private sealed class TagsRequest
        {
            public List<string> Tags { get; set; }
        }

        [Fact]
        public void CreateServiceParameters_SimpleProperty_ProducesSingleParameter()
        {
            var parameters = ServiceHelper.CreateServiceParameters(new SimpleRequest { Issuer = "INGBNL2A" });

            var parameter = Assert.Single(parameters);
            Assert.Equal("Issuer", parameter.Name);
            Assert.Equal("INGBNL2A", parameter.Value);
            Assert.Equal(string.Empty, parameter.GroupType);
            Assert.Equal(string.Empty, parameter.GroupId);
        }

        [Fact]
        public void CreateServiceParameters_NullOrEmptyProperties_AreSkipped()
        {
            var parameters = ServiceHelper.CreateServiceParameters(new SimpleRequest { Issuer = null, Empty = "" });

            Assert.Empty(parameters);
        }

        [Fact]
        public void CreateServiceParameters_Decimal_UsesInvariantCulture_RegardlessOfThreadCulture()
        {
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                // nl-NL uses a comma as decimal separator; the wire format must always use a dot.
                Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");

                var parameters = ServiceHelper.CreateServiceParameters(new AmountRequest { Amount = 12.5m });

                var parameter = Assert.Single(parameters);
                Assert.Equal("Amount", parameter.Name);
                Assert.Equal("12.5", parameter.Value);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }

        [Fact]
        public void CreateServiceParameters_ParameterGroup_TagsParametersWithGroupType()
        {
            var request = new GroupRequest { BillingAddress = new Address { City = "Leiden" } };

            var parameters = ServiceHelper.CreateServiceParameters(request);

            var parameter = Assert.Single(parameters);
            Assert.Equal("City", parameter.Name);
            Assert.Equal("Leiden", parameter.Value);
            Assert.Equal(nameof(Address), parameter.GroupType);
        }

        [Fact]
        public void CreateServiceParameters_GroupName_IsNotEmittedAsParameter()
        {
            var request = new GroupRequest { BillingAddress = new Address { City = "Leiden" } };

            var parameters = ServiceHelper.CreateServiceParameters(request);

            Assert.DoesNotContain(parameters, p => p.Name == nameof(IParameterGroup.GroupName));
        }

        [Fact]
        public void CreateServiceParameters_ParameterGroupCollection_AssignsSequentialGroupIds()
        {
            var request = new ArticleCollectionRequest
            {
                Articles = new ParameterGroupCollection<Address>("Article")
                {
                    new Address { City = "Leiden" },
                    new Address { City = "Utrecht" },
                },
            };

            var parameters = ServiceHelper.CreateServiceParameters(request);

            Assert.Equal(2, parameters.Count);
            Assert.All(parameters, p => Assert.Equal("City", p.Name));
            Assert.All(parameters, p => Assert.Equal("Article", p.GroupType));
            Assert.Equal(new[] { "1", "2" }, parameters.Select(p => p.GroupId).ToArray());
            Assert.Equal(new[] { "Leiden", "Utrecht" }, parameters.Select(p => p.Value).ToArray());
        }

        [Fact]
        public void CreateServiceParameters_PlainEnumerable_RepeatsNameWithSequentialGroupIds()
        {
            var request = new TagsRequest { Tags = new List<string> { "a", "b", "c" } };

            var parameters = ServiceHelper.CreateServiceParameters(request);

            Assert.Equal(3, parameters.Count);
            Assert.All(parameters, p => Assert.Equal("Tags", p.Name));
            Assert.Equal(new[] { "1", "2", "3" }, parameters.Select(p => p.GroupId).ToArray());
        }

        [Theory]
        [InlineData("vpay", "VPayCreditcardNumber")]
        [InlineData("visa", "CreditcardNumber")]
        [InlineData("", "CreditcardNumber")]
        public void CreateServiceParameters_VPay_RenamesCreditcardNumber(string serviceName, string expectedName)
        {
            var parameters = ServiceHelper.CreateServiceParameters(
                new CardRequest { CreditcardNumber = "4111111111111111" }, serviceName);

            var parameter = Assert.Single(parameters);
            Assert.Equal(expectedName, parameter.Name);
        }
    }
}
