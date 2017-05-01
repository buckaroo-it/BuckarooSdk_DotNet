using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class InvoiceInfoResponse : IRequestResponse
	{
		public List<InvoiceInfoResponseInvoice> InvoiceCollection { get; set; }
		public List<InvalidInvoice> InvalidInvoiceCollection { get; set; }
	}
}
