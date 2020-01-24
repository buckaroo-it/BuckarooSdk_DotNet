using BuckarooSdk.DataTypes.ParameterGroups.Afterpay;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayCaptureRequest
	{
		public ParameterGroupCollection<Article> Articles { get; set; }
	}
}
