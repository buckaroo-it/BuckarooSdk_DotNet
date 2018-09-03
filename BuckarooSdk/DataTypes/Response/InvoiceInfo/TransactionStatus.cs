using System;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class TransactionStatus
	{
		public bool Success { get; set; }
		public string Code { get; set; }
		public string Message { get; set; }
		public DateTime DateTime { get; set; }
	}
}
