using System;

namespace BuckarooSdk.Services.Subscriptions.Domain
{
	public class RatePlan : ParameterGroup
	{
		public override string GroupName => "AddRatePlan";
		public string RatePlanCode { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}