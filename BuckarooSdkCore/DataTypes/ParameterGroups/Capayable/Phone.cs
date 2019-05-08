using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Capayable
{
	public class CustomerPhone : ParameterGroup
	{
		public override string GroupName => "Phone";
		public string Phone { get; set; }
		public string Fax { get; set; }
	}
}
