using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3
{
	public class Company : ParameterGroup
	{
		/// <summary>
		/// 
		/// </summary>
		public string ChamberOfCommerce { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool VatApplicable { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string VatNumber { get; set; }
	}
}
