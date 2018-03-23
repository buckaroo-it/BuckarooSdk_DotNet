using System.Collections.Generic;

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
