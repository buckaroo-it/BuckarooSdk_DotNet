using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class SpecificationsRequestResponse : IRequestResponse
	{
		public List<SpecificationResponseFieldDescription> BasicFields { get; set; }
		public List<SpecificationResponseServiceDescription> Services { get; set; }
		public List<CustomParameterSpecification> CustomParameters { get; set; }
	}
}
