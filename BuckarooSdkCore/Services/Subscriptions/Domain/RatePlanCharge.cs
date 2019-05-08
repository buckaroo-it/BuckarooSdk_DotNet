namespace BuckarooSdk.Services.Subscriptions.Domain
{
	public class RatePlanCharge : ParameterGroup
	{
		public override string GroupName => "AddRatePlanCharge";
		public string RatePlanChargeCode { get; set; }
		public decimal BaseNumberOfUnits { get; set; }
		public decimal PricePerUnit { get; set; }
	}
}