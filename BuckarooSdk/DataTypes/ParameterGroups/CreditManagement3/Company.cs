using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3
{
	public class Company : ParameterGroup
	{
		public string ChamberOfCommerce { get; set; }
		public string Name { get; set; }
		public bool VatApplicable { get; set; }
		public string VatNumber { get; set; }
	}
}
