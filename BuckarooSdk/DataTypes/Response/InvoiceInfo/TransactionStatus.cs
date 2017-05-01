using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class TransactionStatus
	{
		public bool Succes { get; set; }
		public string Code { get; set; }
		public string Message { get; set; }
		public DateTime DateTime { get; set; }
	}
}
