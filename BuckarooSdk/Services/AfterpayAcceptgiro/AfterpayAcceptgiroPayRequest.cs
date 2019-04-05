using System;

namespace BuckarooSdk.Services.AfterpayAcceptgiro
{
	public class AfterpayAcceptgiroPayRequest
	{
		public long ShippingCosts { get; set; }

		public long Discount { get; set; }

		public bool Accept { get; set; }

		public string BillingTitle { get; set; }

		public int BillingGender { get; set; }

		public string BillingInitials { get; set; }

		public string BillingLastNamePrefix { get; set; }

		public string BillingLastName { get; set; }

		public DateTime BillingBirthDate { get; set; }

		public string BillingStreet { get; set; }

		public string BillingHouseNumber { get; set; }

		public string BillingHouseNumberSuffix { get; set; }

		public string BillingPostalCode { get; set; }

		public string BillingCity { get; set; }

		public string BillingCountry { get; set; }

		public string BillingEmail { get; set; }

		public string BillingPhoneNumber { get; set; }

		public string BillingLanguage { get; set; }

		public string ShippingTitle { get; set; }

		public int ShippingGender { get; set; }

		public string ShippingInitials { get; set; }

		public string ShippingLastNamePrefix { get; set; }

		public string ShippingLastName { get; set; }

		public string ShippingBirthDate { get; set; }

		public string ShippingStreet { get; set; }

		public string ShippingHouseNumber { get; set; }

		public string ShippingHouseNumberSuffix { get; set; }

		public string ShippingPostalCode { get; set; }

		public string ShippingCity { get; set; }

		public string ShippingCountryCode { get; set; }

		public string ShippingEmail { get; set; }

		public string ShippingPhoneNumber { get; set; }

		public string ShippingLanguage { get; set; }

		public bool AddressesDiffer { get; set; }

		public bool B2B { get; set; }

		public string CustomerAccountNumber { get; set; }

		public string CompanyCOCRegistration { get; set; }

		public long CommissionAmount { get; set; }

		public string CompanyName { get; set; }

		public string CostCentre { get; set; }

		public string Department { get; set; }

		public string EstablishmentNumber { get; set; }

		public string CustomerIPAddress { get; set; }

		public string VatNumber { get; set; }

		public string ArticleDescription { get; set; }

		public string ArticleId { get; set; }

		public int ArticleQuantity { get; set; }

		public long ArticleUnitprice { get; set; }

		public int ArticleVatcategory { get; set; }

		public long ArticleNetUnitprice { get; set; }
	}
}
