using System;

namespace BuckarooSdk.Services.Afterpay
{

	public class AfterpayAuthorizeRequest
	{
		public string ImageUrl { get; set; }

		public string Description { get; set; }

		public string PostalCode { get; set; }

		public string BankCode { get; set; }
		
		public string Url { get; set; }

		public string BankAccount { get; set; }

		public string Salutation { get; set; }

		public string Quantity { get; set; }

		public string FirstName { get; set; }

		public string Street { get; set; }

		public string UnitCode { get; set; }

		public string Category { get; set; }

		public string Type { get; set; }

		public string MobilePhone { get; set; }

		public string StreetNumberAdditional { get; set; }

		public string IdentificationNumber { get; set; }

		public string MerchantImageUrl { get; set; }

		public long VatPercentage { get; set; }

		public string Country { get; set; }

		public string Identifier { get; set; }

		public DateTime BirthDate { get; set; }

		public string StreetNumber { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string VatCategory { get; set; }

		public string City { get; set; }

		public string ConversationLanguage { get; set; }

		public string SummaryImageUrl { get; set; }

		public long GrossUnitPrice { get; set; }

		public string Phone { get; set; }

		public string CareOf { get; set; }

		public string CustomerNumber { get; set; }
	}
}
