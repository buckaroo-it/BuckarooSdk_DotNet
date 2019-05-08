using BuckarooSdk.DataTypes.Response;

namespace BuckarooSdk.DataTypes
{
	public class InvoiceInfoRequestInvoice : IRequestResponse
	{
		public string Key { get;set; }
		public string Number { get; set; }
		public string CustomerId { get; set; }
	}
}
