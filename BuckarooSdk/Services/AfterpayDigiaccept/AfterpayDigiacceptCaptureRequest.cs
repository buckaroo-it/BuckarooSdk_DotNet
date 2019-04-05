namespace BuckarooSdk.Services.AfterpayDigiaccept
{
	public class AfterpayDigiacceptCaptureRequest
	{
		public string ArticleDescription { get; set; }

		public string ArticleId { get; set; }

		public int ArticleQuantity { get; set; }

		public long ArticleUnitprice { get; set; }

		public int ArticleVatcategory { get; set; }

		public long ArticleNetUnitprice { get; set; }
	}
}
