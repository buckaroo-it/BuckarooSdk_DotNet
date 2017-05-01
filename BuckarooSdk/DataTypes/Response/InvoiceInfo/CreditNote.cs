using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class CreditNote
	{
		public string Number { get; set; }
		public decimal Amount { get; set; }
		public decimal AmountVat { get; set; }
		public string Description { get; set; }
	}
}
