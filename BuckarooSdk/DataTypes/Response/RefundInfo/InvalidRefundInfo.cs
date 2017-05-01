using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.RefundInfo
{
	public class InvalidRefundInfo
	{
		public string TransactionKey { get; set; }
		public string ErrorMessage { get; set; }
	}
}