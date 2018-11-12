namespace BuckarooSdk.Services.Emandates.DataRequest
{
	public class EmandatesModifyMandateRequest
	{
		/// <summary>
		/// The bank id of the consumer (BIC), the possible values can be retrieved with the GetIssuerList action. This information is required, 
		/// but it is possible to let the customer fill it in on the Buckaroo checkout page. In that case, leave the debtorbankid parameter out 
		/// and add the basic parameter "ContinueOnIncomplete" with a value of 1.
		/// </summary>
		public string DebtorBankId { get; set; }

		/// <summary>
		/// Required 
		/// An ID that identifies the debtor to creditor, which is issued by the creditor.For example: a customer number/ID.Max. 35 characters.
		/// </summary>
		public string DebtorReference { get; set; }

		/// <summary>
		/// Required 
		/// Indicates type of eMandate: one-off or recurring direct debit. 0 = recurring, 1 = one off.
		/// </summary>
		public string SequenceType { get; set; }

		/// <summary>
		/// Required
		/// An ID that identifies the emandate with a purchase order. This will be shown in the emandate information of the customers' bank account. 
		/// Max. 35 characters.
		/// </summary>
		public string PurchaseId { get; set; }

		/// <summary>
		/// Required
		/// The consumer language code in lowercase letters. For example “nl”, not “NL” or “nl-NL”.
		/// </summary>
		public string Language { get; set; }


		/// <summary>
		///A description of the (purpose) of the emandate. This will be shown in the emandate information of the customers' bank account.
		/// </summary>
		public string EmandateReason { get; set; }

		/// <summary>
		/// Required
		/// The mandateId or “mandate reference” of the original e-Mandate.This will not change after a successful amendment.
		/// </summary>
		public string OrignialMandateId { get; set; }

		/// <summary>
		/// Required
		/// The iban of the original e-Mandate
		/// </summary>
		public string OriginalIban { get; set; }

		/// <summary>
		/// Required
		/// The debtorbank id of the original e-Mandate
		/// </summary>
		public string OriginalDebtorBankId { get; set; }

		/// <summary>
		/// This is the maximal amount per SEPA Direct Debit. Debtor can change this value during the athorisation process. The 
		/// (altered) value will be communicated in the push message to the Merchant. This parameter is for B2B only and required if that's the case.
		/// </summary>
		public string MaxAmount { get; set; }

	}
}
