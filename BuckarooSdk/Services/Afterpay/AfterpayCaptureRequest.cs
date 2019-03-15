namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayCaptureRequest
	{
		public long GrossUnitPrice { get; set; }

		public string MerchantImageUrl { get; set; }

		public string ImageUrl { get; set; }

		public string Description { get; set; }

		public string SummaryImageUrl { get; set; }

		public string Url { get; set; }

		public string Quantity { get; set; }

		public string UnitCode { get; set; }

		public string Type { get; set; }

		public long VatPercentage { get; set; }

		public string Identifier { get; set; }
	}
}
