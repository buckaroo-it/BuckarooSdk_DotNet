using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class SpecificationResponseServiceDescription
	{
		public List<SupportedCurrency> SupportedCurrencies { get; set; }
		public List<SpecificationResponseActionDescription> Actions { get; set; }
		public string Name { get; set; }
		public int Version { get; set; }
		public string Description { get; set; }
	}
}
