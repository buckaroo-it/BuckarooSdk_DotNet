using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Capayable
{
	public class EmailAddress : ParameterGroup
	{
		public override string GroupName => "Email";
		public string Email { get; set; }
	}
}
