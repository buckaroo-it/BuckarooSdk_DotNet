namespace BuckarooSdk.Services.Emandates.DataRequest
{
	/// <summary>
	/// This action can be used to cancel a business E-mandate. This option is only available for the b2b service. In that case the Mandate can be 
	/// blocked by the settings within the online banking environment of the consumer. Please note that you are legally required to offer this to 
	/// your customers when you are making use of B2B e-mandates. Furthermore, the debtor has the option of canceling the mandate in his bank environment 
	/// anyways. If you offer the option on your own website, you get the benefit of knowing when the customer cancels the mandate.
	/// </summary>
	public class EmandatesCancelMandateRequest
	{
		/// <summary>
		/// Required
		/// The mandateId or “mandate reference” of the original e-Mandate.
		/// </summary>
		public string MandateId { get; set; }

		/// <summary>
		/// Required
		/// An ID that identifies the emandate with a purchase order. This will be shown in the emandate information 
		/// of the customers' bank account. Max. 35 characters.
		/// </summary>
		public string Purchaseid { get; set; }

		/// <summary>
		/// A description of the (purpose) of the emandate. This will be shown in the emandate information of the 
		/// customers' bank account.
		/// </summary>
		public string Emandatereason { get; set; }
	}
}