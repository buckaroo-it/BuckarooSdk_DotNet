using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Afterpay
{
	public class Article : ParameterGroup
	{
		public string Description { get; set; }
		public string GrossUnitPrice { get; set; }
		public string VatPercentage { get; set; }
		public int Quantity { get; set; }
		public string Identifier { get; set; }
		public string ImageUrl { get; set; }
		public string Url { get; set; }
		/// <summary>
		/// Possible values: PhysicalArticle, DigitalArticle, Giftcard, Discount, ShippingFee, Surcharge, Info, ShippingFees.
		/// </summary>
		public string Type { get; set; }
		public string UnitCode { get; set; }
        public string RefundType { get; set; }
	}
}
