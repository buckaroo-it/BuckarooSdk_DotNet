using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class SpecificationResponseActionDescription
	{
		public string Name { get; set; }
		public int Type { get; set; }
		public bool Default { get; set; }
		public string Description { get; set; }
		public List<ParameterDescription> RequestParameters { get; set; }
		public List<ParameterDescription> ResponseParameters { get; set; }
		public List<OriginalTransactionReferenceDescription> OriginalTransactionReferenceDescriptions { get; set; }


	}
}
