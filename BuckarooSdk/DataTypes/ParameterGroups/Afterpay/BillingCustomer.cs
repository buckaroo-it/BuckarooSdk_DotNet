using BuckarooSdk.Services;
using System;

namespace BuckarooSdk.DataTypes.ParameterGroups.Afterpay
{
    public class BillingCustomer : ParameterGroup
	{
		/// <summary>
		/// GroupType: BillingCustomer. Customer category of billing customer. Possible values: Person, Company. 
		/// </summary>
		public string Category { get; set; }
		/// <summary>
		/// Required if Billing country is NL or BE. Gender of billing customer. Possible values: Mr, Mrs, Miss.
		/// </summary>
		public string Salutation { get; set; }
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
		/// Address
		/// </summary>
		public string Street { get; set; }
		/// <summary>
		/// GroupType: BillingCustomer. Required if Billing country is NL or BE. House number of billing customer.
		/// </summary>
		public string StreetNumber { get; set; }
		public string StreetNumberAdditional { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		/// <summary>
		/// Required
		///	GroupType: BillingCustomer.Country of billing customer.Possible values: NL, BE, DE, AT, FI.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// GroupType: BillingCustomer. If Billing country is NL or BE, at least one phone number is required: either MobilePhone or Phone (landline).
		/// </summary>
		public string MobilePhone { get; set; }
		/// <summary>
		/// GroupType: BillingCustomer. If Billing country is NL or BE, at least one phone number is required: either MobilePhone or Phone (landline).
		/// </summary>
		public string Phone { get; set; }
		public string Email { get; set; }

		/// <summary>
		/// GroupType: BillingCustomer. Name of intermediary who is responsible for transferring a piece of mail between the postal system and the final addressee. 
		/// For example Jane c/o John (“Jane at John's address”). 
		/// This field has to be used for company, authority and organization names as well - e. g. "Sportverein Blau-Weiß e.V.
		/// </summary>
		public string CareOf { get; set; }
		/// <summary>
		/// GroupType: BillingCustomer. Conversation language of billing customer. Possible values: NL, FR, DE, FI.
		/// </summary>
		public string ConversationLanguage { get; set; }

		/// <summary>
		/// GroupType: BillingCustomer. Required if Billing Country is Finland (FI). The customer’s national ID number, or the company’s registration number, 
		/// depending on Category (Person or Company). Do not confuse with CustomerNumber.
		/// </summary>
		public string IdentificationNumber { get; set; }
		/// <summary>
		/// GroupType: BillingCustomer. The number you assign to the billing customer.
		/// </summary>
		public string CustomerNumber { get; set; }
	}
}
