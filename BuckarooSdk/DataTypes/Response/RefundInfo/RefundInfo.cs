using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.RefundInfo
{
	public class RefundInfo : IRequestResponse
	{
		public List<RefundInfoResponseRefundInfo> RefundInfoCollection { get; set; }
		public List<InvalidRefundInfo> InvalidRefundInfoCollection { get; set; }
	}
}
