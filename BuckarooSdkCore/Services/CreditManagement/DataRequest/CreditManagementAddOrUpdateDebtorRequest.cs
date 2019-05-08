using BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	public class CreditManagementAddOrUpdateDebtorRequest
	{
		/// <summary>
		/// The code of the invoice.
		/// </summary>W
		public string Code { get; set; }
		/// <summary>
		/// The debtor parameter group.
		/// </summary>
		public Debtor Debtor { get; set; }
		/// <summary>
		/// The Person parameter group.
		/// </summary>
		public Person Person { get; set; }
		/// <summary>
		/// The Person parameter group.
		/// </summary>
		public Address Address { get; set; }
		/// <summary>
		/// The Email parameter group.
		/// </summary>
		public EmailAddress Email { get; set; }
		/// <summary>
		/// The Phone parameter group.
		/// </summary>
		public Phone Phone { get; set; }
	}
}
