using System;

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
