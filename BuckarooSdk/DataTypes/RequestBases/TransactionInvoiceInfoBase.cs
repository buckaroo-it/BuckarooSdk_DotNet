using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.RequestBases
{
	public class TransactionInvoiceInfoBase : IRequestBase
	{
		public List<InvoiceInfoRequestInvoice> InvoiceCollection { get; set; }
	}
}
