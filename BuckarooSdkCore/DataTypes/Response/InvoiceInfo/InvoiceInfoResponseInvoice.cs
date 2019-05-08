using System;
using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.InvoiceInfo
{
	public class InvoiceInfoResponseInvoice : IRequestResponse
	{
		public string Key { get; set; }
		public string Number { get; set; }
		public string CustomerId { get; set; }
		public bool CreditManagement { get; set; }
		public bool Test { get; set; }
		public CreditManagementStatus Status { get; set; }
		public bool Paid { get; set; }
		public string Paylink { get; set; }
		public string Currency { get; set; }
		public decimal AmountDebit { get; set; }
		public decimal AmountCredit { get; set; }
		public decimal AmountVat { get; set; }
		public decimal AmountCreditVat { get; set; }
		public decimal AmountPaid { get; set; }
		public decimal SurchargeAmount { get; set; }
		public int MaxReminderLevel { get; set; }
		public DateTime InvoiceDate { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime CreatedDatetime { get; set; }
		public DateTime StatusDatetime { get; set; }
		public DateTime EstimatedNextStepDate { get; set; }
		public List<CreditNote> CreditNotes { get; set; }
		public List<Transaction> Transactions { get; set; }
		public string Order { get; set; }
	}
}
