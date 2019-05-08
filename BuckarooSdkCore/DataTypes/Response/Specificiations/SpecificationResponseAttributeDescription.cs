using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class SpecificationResponseAttributeDescription
	{
		public List<ListItemDescription> ListItemDescriptions { get; set; }
		public string Name { get; set; }
		public int DataType { get; set; }
		public int MaxLength { get; set; }
		public bool Required { get; set; }
		public string Description { get; set; }
	}
}