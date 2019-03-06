namespace BuckarooSdk.Services.EMandate
{
	public class EMandateGetStatusResponse
	{
		public string OriginalMandateId { get; set; }

		public string AccountName { get; set; }

		public string ValidationReference { get; set; }

		public string SignerName { get; set; }

		public string Reference { get; set; }

		public string Iban { get; set; }

		public string EmandateStatus { get; set; }

		public string BankId { get; set; }
	}
}
