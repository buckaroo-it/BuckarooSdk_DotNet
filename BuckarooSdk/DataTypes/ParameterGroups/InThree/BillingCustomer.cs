using System;

namespace BuckarooSdk.DataTypes.ParameterGroups.InThree
{
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
        public string Email { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// GroupType: BillingCustomer. Required if Billing country is NL or BE. House number of billing customer.
        /// </summary>
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StreetNumberSuffix { get; set; }
        /// <summary>
        /// GroupType: BillingCustomer. Customer category of billing customer. Possible values: Person, Company. 
        /// </summary>
        public string Category { get; set; }
        public string Initials { get; set; }
        public string CompanyName { get; set; }
        public string CountryCode { get; set; }
        public string CocNumber { get; set; }
    }
}
