using System.Collections.Generic;
using BuckarooSdk.DataTypes.Response.Specificiations;

namespace BuckarooSdk.DataTypes.Response.RefundInfo
{
	public class ParameterDescription
	{
		public string Name { get; set; }
		public DataType DataType { get; set; }
		public ListType List { get; set; }
		public string MaxLength { get; set; }
		public string MaxOccurs { get; set; }
		public string Required { get; set; }
		public string Global { get; set; }
		public string Group { get; set; }
		public string Description { get; set; }
		public string ExplanationHtml { get; set; }
		public string DisplayName { get; set; }
		public string InputPattern { get; set; }
		public string AutoCompleteType { get; set; }
		public List<ListItemDescription> ListItemDescriptions { get; set; }
	}
}
