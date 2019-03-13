using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Emandates.DataRequest
{
	public class EmandatesGetStatusResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Emandates;

		/// <summary>
		/// Status of emandate
		/// </summary>
		public string EmandateStatus { get; set; }

		/// <summary>
		/// Name of the person signing the eMandate.
		/// </summary>
		public string SignerName { get; set; }

		/// <summary>
		/// Name of the bank account as it is registered at the bank.
		/// </summary>
		public string AccountName { get; set; }

		/// <summary>
		/// BIC code of the debtor’s bank.
		/// </summary>
		public string BankId { get; set; }

		/// <summary>
		/// Debtor’s bank account number.
		/// </summary>
		public string Iban { get; set; }

		/// <summary>
		/// Reference ID that identifies the debtor to creditor, which is issued by the creditor.
		/// </summary>
		public string Reference { get; set; }

		/// <summary>
		/// The ValidationReference can be used in a (Simple) SEPA Direct Debit transaction as the Electronic Signature. 
		/// It is advised to save this value somewhere. However, you can provide only the MandateId / MandateReference in your 
		/// (Simple) SEPA Direct Debit request and Buckaroo will find the matching ValidationReference.
		/// </summary>
		public string ValidationReference { get; set; }

		/// <summary>
		/// The mandateId or “mandate reference”.
		/// </summary>
		public string OriginalMandateId { get; set; }

		/// <summary>
		/// The authorized maximum amount for a SEPA Direct Debit. This amount can be different from the requested amount.
		/// </summary>
		public string MaxAmount { get; set; }
	}
}