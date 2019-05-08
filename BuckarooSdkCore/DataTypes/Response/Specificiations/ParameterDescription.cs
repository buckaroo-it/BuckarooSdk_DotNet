using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class ParameterDescription
	{
		public List<ListItemDescription> ListItemDescriptions { get; set; }
		public bool IsRequestParameter { get; set; }
		public string Name { get; set; }
		public int DataType { get; set; }
		public int MaxLength { get; set; }
		public int MaxOccurs { get; set; }
		public bool Required { get; set; }
		public bool Global { get; set; }
		public string Group { get; set; }
		public string Description { get; set; }
		public string ExplanationHtml { get; set; }
		public string DisplayName { get; set; }
		public string InputPattern { get; set; }
		public string AutoCompleteType { get; set; }
	}
}
