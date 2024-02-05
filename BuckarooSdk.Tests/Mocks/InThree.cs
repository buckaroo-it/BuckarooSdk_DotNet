using BuckarooSdk.DataTypes.ParameterGroups.InThree;
using BuckarooSdk.Services.InThree;
using System;

namespace BuckarooSdk.Tests.Mocks
{
    internal class InThree
    {
        internal static InThreePayRequest InThreePayMock => new InThreePayRequest()
        {

            BillingCustomer = new BillingCustomer()
            {
                Category = "Person",
                FirstName = "Tester",
                LastName = "de Tester",
                BirthDate = new DateTime(1992, 6, 3),
                Street = "Zonnebaan",
                StreetNumber = "9",
                PostalCode = "3542 EA",
                City = "UTRECHT",
                CountryCode = "NL",
                Phone = "0713613412",
                Email = "tester@test.nl",
                CustomerNumber = "Tester Test",
            },
            ShippingCustomer = new ShippingCustomer()
            {
                Street = "Zonnebaan",
                StreetNumber = "10",
                PostalCode = "3542 EA",
                City = "UTRECHT",
            },
            Articles = new BuckarooSdk.Services.ParameterGroupCollection<Article>("Article")
            {
                new Article()
                {
                    Description = "Blue Toy Car",
                    GrossUnitPrice = "2.00",
                    Quantity = 1,
                }
            }
        };

        internal static InThreeRefundRequest InThreeRefundMock() => new InThreeRefundRequest()
        {
        };
    }
}
