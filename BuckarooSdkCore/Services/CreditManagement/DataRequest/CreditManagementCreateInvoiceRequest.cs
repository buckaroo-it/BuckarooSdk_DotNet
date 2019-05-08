using System;
using BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	public class CreditManagementCreateInvoiceRequest
	{
		/// <summary>
		/// The VAT amount of the invoice that has to be created.
		/// </summary>
		public decimal InvoiceAmountVat { get; set; }
		/// <summary>
		/// The date of the invoice as stated on the invoice.
		/// </summary>
		public DateTime InvoiceDate { get; set; }
		/// <summary>
		/// The maximum step that the invoice should be taken to in the credit management
		/// process.
		/// </summary>
		public int? MaxStepIndex { get; set; }
		/// <summary>
		/// The date on which the invoice should be paid. 
		/// </summary>
		public DateTime DueDate { get; set; }
		/// <summary>
		/// The key of the scheme that should be used for the created invoice.
		/// </summary>
		public string SchemeKey { get; set; }
		/// <summary>
		/// The amount of the invoice.
		/// </summary>
		public decimal InvoiceAmount { get; set; }
		/// <summary>
		/// The services that are not allowed to be used when paying this invoice.
		/// </summary>
		public string DisallowedServices { get; set; }
		/// <summary>
		/// The services that are allowed to be used when paying this invoice.
		/// </summary>
		public string AllowedServices { get; set; }	
		/// <summary>
		/// The code of the invoice.
		/// </summary>
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
