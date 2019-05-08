using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.RefundInfo
{
	public class RefundInfoResponseRefundInfo : IRequestResponse
	{
		public string TransactionKey { get; set; }
		public bool IsRefundable { get; set; }
		public string NotRefundableExplanation { get; set; }
		public bool AllowPartialRefund { get; set; }
		public decimal MaximumRefundAmount { get; set; }
		public decimal PendingRefundAmount { get; set; }
		public decimal RefundedAmount { get; set; }
		public string RefundCurrency { get; set; }
		public string ServiceCode { get; set; }
		public List<RefundInputField> RefundInputFields { get; set; }
		public bool IsCreditmanagement { get; set; }
		public string Invoice { get; set; }
		public decimal InvoiceAmount { get; set; }
		public decimal InvoiceAmountPaid { get; set; }
		public decimal InvoiceAmountOpen { get; set; }
		public bool CanCreateCreditNote { get; set; }
		public decimal CreditNoteAmount { get; set; }
		public bool CanBeCancelled { get; set; }
		public bool UsesBalance { get; set; }
		public string AdditionalMessage { get; set; }
	}
}
