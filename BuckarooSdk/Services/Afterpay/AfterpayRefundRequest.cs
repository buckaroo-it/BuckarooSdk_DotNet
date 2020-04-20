using BuckarooSdk.DataTypes.ParameterGroups.Afterpay;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayRefundRequest
	{
        public AfterpayRefundRequest(string refundType)
        {
            this.RefundType = refundType;
        }

		public ParameterGroupCollection<Article> Articles { get; set; }
		public string RefundType { get; set; }
	}
}
