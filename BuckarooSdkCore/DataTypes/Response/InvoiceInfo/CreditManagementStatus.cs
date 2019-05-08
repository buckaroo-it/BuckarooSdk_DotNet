using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class CreditManagementStatus
	{
		public int CmStatus { get; set; }
		public bool Running { get; set; }
		public int RemindersSent { get; set; }
		public int AgencyStatusAsString { get; set; }
		public List<AgencyUpdate> AgencyUpdates { get; set; }
	}
}
