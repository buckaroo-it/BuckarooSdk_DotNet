using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Subscriptions
{
	public class RatePlanCharge : ParameterGroup
	{
		public override string GroupName => "AddRatePlanCharge";
		public string RatePlanChargeCode { get; set; }
		public decimal BaseNumberOfUnits { get; set; }
		public decimal PricePerUnit { get; set; }
	}
}