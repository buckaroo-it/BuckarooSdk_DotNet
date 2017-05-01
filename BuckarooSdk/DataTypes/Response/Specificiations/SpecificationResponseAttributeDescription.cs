using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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