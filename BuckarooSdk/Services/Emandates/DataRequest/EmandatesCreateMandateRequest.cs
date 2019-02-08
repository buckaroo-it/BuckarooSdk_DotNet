namespace BuckarooSdk.Services.Emandates.DataRequest
{
	/// <summary>
	/// This action creates an e-Mandate request and returns a URL where to the consumer can be redirected to approve the request. 
	/// </summary>
	public class EmandatesCreateMandateRequest
	{
		/// <summary>
		/// A description of the (purpose) of the emandate. This will be shown in the emandate information of the customers' bank account.
		/// </summary>
		public string EmandateReason { get; set; }

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
		/// The consumer language code in lowercase letters. For example “nl”, not “NL” or “nl-NL”.
		/// </summary>
		public string Language { get; set; }
	}
}
