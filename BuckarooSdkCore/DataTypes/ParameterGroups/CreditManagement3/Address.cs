using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3
{
	public class Address : ParameterGroup
	{
		public string Street { get; set; }
		public string HouseNumber { get; set; }
		public string HouseNumberSuffix { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}
}
