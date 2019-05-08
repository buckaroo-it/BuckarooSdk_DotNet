using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3
{
	public class Phone : ParameterGroup
	{
		/// <summary>
		/// The consumer mobile phonenumber
		/// </summary>
		public string Mobile { get; set; }
		/// <summary>
		/// The consumer landline phonenumber
		/// </summary>
		public string Landline { get; set; }
		/// <summary>
		/// The consumer fax number
		/// </summary>
		public string Fax { get; set; }

	}
}
