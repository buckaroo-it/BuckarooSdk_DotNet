namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayRefundRequest
	{
		public string Url { get; set; }

		public string Quantity { get; set; }

		public string UnitCode { get; set; }

		public string Type { get; set; }

		public string RefundType { get; set; }

		public long VatPercentage { get; set; }

		public string VatCategory { get; set; }

		public long GrossUnitPrice { get; set; }

		public string ImageUrl { get; set; }

		public string Description { get; set; }
	}
}
