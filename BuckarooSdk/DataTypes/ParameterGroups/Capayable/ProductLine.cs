using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Capayable
{
	public class ProductLine : ParameterGroup
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public long Quantity { get; set; }
		public long Price { get; set; }
	}
}
