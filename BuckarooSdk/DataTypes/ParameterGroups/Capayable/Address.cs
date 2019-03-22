using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Capayable
{
	public class Address : ParameterGroup
	{
		public string Street { get; set; }
		public int HouseNumber { get; set; }
		public string HouseNumberSuffix { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
