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
