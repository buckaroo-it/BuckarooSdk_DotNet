using BuckarooSdk.Services;
using System;

namespace BuckarooSdk.DataTypes.ParameterGroups.Subscriptions
{
	public class RatePlan : ParameterGroup
	{
		public override string GroupName => "AddRatePlan";
		public string RatePlanCode { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}