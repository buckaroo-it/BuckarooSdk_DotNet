using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Klarna
{
    public class Article : ParameterGroup
	{
		public string ArticleTitle { get; set; }
		public string ArticleNumber { get; set; }
		public string ArticleType { get; set; }
		public int ArticleQuantity { get; set; }
		public decimal ArticlePrice { get; set; }
		public decimal ArticleVat { get; set; }
		public decimal ArticleDiscount { get; set; }
	}
}
