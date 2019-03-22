using System;
using BuckarooSdk.DataTypes.ParameterGroups.Capayable;

namespace BuckarooSdk.Services.Capayable
{
	public class CapayablePayInInstallmentsRequest
	{
		public string CustomerType { get; set; }

		public string IsInThreeGuarantee { get; set; }

		public Person Person { get; set; }

		public Address Address { get; set; }

		public CustomerPhone Phone { get; set; }

		public EmailAddress Email { get; set; }

		public Company Company { get; set; }

		public DateTime InvoiceDate { get; set; }

		public ProductLine ProductLine { get; set; }

		public SubTotalLine SubTotalLine { get; set; }
	}
}
