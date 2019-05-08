namespace BuckarooSdk.Services.EMandate
{
	public class EMandateModifyMandateRequest
	{
		public string OriginalIBAN { get; set; }

		public string PurchaseId { get; set; }

		public string OriginalDebtorBankId { get; set; }

		public string EMandateReason { get; set; }

		public int SequenceType { get; set; }

		public string OriginalMandateId { get; set; }

		public string DebtorBankId { get; set; }

		public string Language { get; set; }

		public string DebtorReference { get; set; }
	}
}
