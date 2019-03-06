namespace BuckarooSdk.Services.EMandate
{
	public class EMandateCreateMandateRequest
	{
		public string EMandateReason { get; set; }

		public int SequenceType { get; set; }

		public string PurchaseId { get; set; }

		public string DebtorBankId { get; set; }

		public string MandateId { get; set; }

		public string DebtorReference { get; set; }

		public string Language { get; set; }
	}
}
