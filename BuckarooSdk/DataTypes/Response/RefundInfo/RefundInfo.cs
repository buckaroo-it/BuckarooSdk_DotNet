using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.RefundInfo
{
	public class RefundInfo : IRequestResponse
	{
		public List<RefundInfoResponseRefundInfo> RefundInfoCollection { get; set; }
		public List<InvalidRefundInfo> InvalidRefundInfoCollection { get; set; }
	}
}
