using System;

namespace BuckarooSdk.DataTypes.ParameterGroups.InThree
{
    /// <summary>
    /// Represents a billing customer.
    /// </summary>
    public class BillingCustomer
    {
        /// <summary>
        /// GroupType: BillingCustomer. The number you assign to the billing customer.
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Required
        /// GroupType: BillingCustomer. First name of billing customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Required
        /// GroupType: BillingCustomer. Last name of billing customer, prefix included.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Required if Billing country is NL or BE. Birth date of billing customer. 
        /// Accepted formats: dd-mm-yyyy and yyyy-mm-dd.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. If Billing country is NL or BE, at least one phone number is required: either MobilePhone or Phone (landline).
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Email address of the billing customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Street of billing customer.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Required if Billing country is NL or BE. House number of billing customer.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Postal code of billing customer.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. City of billing customer.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Suffix for street number of billing customer.
        /// </summary>
        public string StreetNumberSuffix { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Customer category of billing customer. Possible values: Person, Company. 
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Initials of billing customer.
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Name of the company of the billing customer.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. Country code of billing customer.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// GroupType: BillingCustomer. COC number of the billing customer.
        /// </summary>
        public string CocNumber { get; set; }
    }
}
