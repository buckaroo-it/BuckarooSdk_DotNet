namespace BuckarooSdk.DataTypes.ParameterGroups.InThree
{
    /// <summary>
    /// Represents a shipping customer.
    /// </summary>
    public class ShippingCustomer
    {
        /// <summary>
        /// GroupType: ShippingCustomer. Street of the shipping address.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// GroupType: ShippingCustomer. Street number of the shipping address.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// GroupType: ShippingCustomer. Suffix for street number of the shipping address.
        /// </summary>
        public string StreetNumberSuffix { get; set; }

        /// <summary>
        /// GroupType: ShippingCustomer. City of the shipping address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// GroupType: ShippingCustomer. Postal code of the shipping address.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// GroupType: ShippingCustomer. Country code of the shipping address.
        /// </summary>
        public string CountryCode { get; set; }
    }
}
