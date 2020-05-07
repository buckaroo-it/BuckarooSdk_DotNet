using BuckarooSdk.DataTypes.ParameterGroups.Afterpay;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayRefundRequest
	{
		public ParameterGroupCollection<Article> Articles { get; set; }
    }
}
