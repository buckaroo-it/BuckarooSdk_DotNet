using BuckarooSdk.DataTypes.ParameterGroups.Klarna;

namespace BuckarooSdk.Services.Klarna
{
	public class KlarnaReserveRequest
	{
		public string BillingPhoneNumber { get; set; }

		public Article Article { get; set; }

		public string ShippingCountry { get; set; }

		public string ShippingCity { get; set; }

		public string ShippingCompany { get; set; }

		public string BillingHouseNumber { get; set; }

		public string ShippingLastName { get; set; }

		public string BillingCompanyName { get; set; }

		public string BillingLastName { get; set; }

		public string ShippingCellPhoneNumber { get; set; }

		public string BillingHouseNumberSuffix { get; set; }

		public string BillingEmail { get; set; }

		public string ShippingFirstName { get; set; }

		public string BillingCareOf { get; set; }

		public string BillingStreet { get; set; }

		public string Encoding { get; set; }

		public int Gender { get; set; }

		public string BillingPostalCode { get; set; }

		public string BillingCountry { get; set; }

		public string ShippingHouseNumberSuffix { get; set; }

		public int PClass { get; set; }

		public string OperatingCountry { get; set; }

		public string BillingCellPhoneNumber { get; set; }

		public string ShippingPostalCode { get; set; }

		public string ShippingStreet { get; set; }

		public string BillingCity { get; set; }

		public string Pno { get; set; }

		public string ShippingHouseNumber { get; set; }

		public bool ShippingSameAsBilling { get; set; }

		public string ShippingEmail { get; set; }

		public string ShippingCareOf { get; set; }

		public string BillingFirstName { get; set; }

		public string ShippingPhoneNumber { get; set; }
	}
}
