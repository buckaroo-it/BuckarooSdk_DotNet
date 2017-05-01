using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class Refund
	{
		public string Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime RefundDate { get; set;}
		public TransactionStatus Status { get; set; }
	}
}
