using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.DataTypes.Response;

namespace BuckarooSdk.DataTypes
{
	public class RefundInfoRequestRefundInfo : IRequestResponse
	{
		public string TransactionKey { get; set; }
	}
}
