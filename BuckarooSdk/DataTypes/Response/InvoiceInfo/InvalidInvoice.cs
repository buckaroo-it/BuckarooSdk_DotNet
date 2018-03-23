namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class InvalidInvoice
	{
		public string Key { get; set; }
		public string Number { get; set; }
		public string CustomerId { get; set; }
		public string ErrorMessage { get; set; }
	}
}
