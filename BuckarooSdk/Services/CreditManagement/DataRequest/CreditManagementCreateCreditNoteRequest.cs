using System;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	public class CreditManagementCreateCreditNoteRequest
	{
		/// <summary>
		/// The date as stated on the invoice.
		/// </summary>
		public DateTime InvoiceDate { get; set; }
		/// <summary>
		/// The invoice number as stated on the original invoice.
		/// </summary>
		public string OriginalInvoiceNumber { get; set; }
		/// <summary>
		/// Message that is send with the credit note.
		/// </summary>
		public string SendCreditNoteMessage { get; set; }
		/// <summary>
		/// the amount of the credit note invoice.
		/// </summary>
		public decimal InvoiceAmount { get; set; }
		/// <summary>
		/// the VAt amount of the credit note invoice.
		/// </summary>
		public decimal InvoiceAmountVat { get; set; }
	}
}
