using BuckarooSdk.DataTypes.ParameterGroups.InThree;

namespace BuckarooSdk.Services.InThree
{
    public class InThreePayRequest
    {
        public ParameterGroupCollection<Article> Articles { get; set; }
        public BillingCustomer BillingCustomer { get; set; }
        public ShippingCustomer ShippingCustomer { get; set; }
    }
}
