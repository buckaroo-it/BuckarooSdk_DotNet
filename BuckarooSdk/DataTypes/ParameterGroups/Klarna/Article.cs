using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Klarna
{
	public class Article : ParameterGroup
	{
		public string ArticleTitle { get; set; }
		public string ArticleNumber { get; set; }
		public string ArticleType { get; set; }
		public int ArticleQuantity { get; set; }
		public long ArticlePrice { get; set; }
		public long ArticleVat { get; set; }
		public long ArticleDiscount { get; set; }
	}
}
