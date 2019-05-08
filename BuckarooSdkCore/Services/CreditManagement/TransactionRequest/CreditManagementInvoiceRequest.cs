using System;
using BuckarooSdk.DataTypes.ParameterGroups.CreditManagement3;

namespace BuckarooSdk.Services.CreditManagement.TransactionRequest
{
	public class CreditManagementInvoiceRequest
	{
		/// <summary>
		/// The VAT amount of the invoice
		/// </summary>
		public decimal InvoiceAmountVat { get; set; }
		/// <summary>
		/// required = true. 
		/// The date corresponding to the invoice
		/// </summary>
		public DateTime InvoiceDate { get; set; }
		/// <summary>
		/// The maximum step index that is to be used in the credit management scheme.
		/// </summary>
		public int? MaxStepIndex { get; set; }
		/// <summary>
		/// The date that the invoice is due for payment. If not paid, the invoice will be put to the next
		/// step in the creditmanagement scheme.
		/// </summary>
		public DateTime DueDate { get; set; }
		/// <summary>
		/// The key of the scheme that is to be used for this invoice.
		/// </summary>
		public string SchemeKey { get; set; }
		/// <summary>
		/// The amount of the invoice that has to be created
		/// </summary>
		public decimal InvoiceAmount { get; set; }
		/// <summary>
		/// The services that are not allowed to be used when paying this invoice.
		/// </summary>
		public string DisallowedServices { get; set; }
		/// <summary>
		/// The services that are allowed to be used when paying this invoice
		/// </summary>
		public string AllowedServices { get; set; }		
		/// <summary>
		/// Parameter group Debtor
		/// </summary>
		public Debtor Debtor { get; set; }
		/// <summary>
		/// Parameter group Person
		/// </summary>
		public Person Person { get; set; }
		/// <summary>
		/// Parameter group Address
		/// </summary>
		public Address Address { get; set; }
		/// <summary>
		/// Parameter group Email
		/// </summary>
		public EmailAddress Email { get; set; }
		/// <summary>
		/// Parameter group Phone
		/// </summary>
		public Phone Phone { get; set; }	
	}
}
