using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class CustomParameterSpecification
	{
		public string Description { get; set; }
		public int DataType { get; set; }
		public string Name { get; set; }
	}
}
