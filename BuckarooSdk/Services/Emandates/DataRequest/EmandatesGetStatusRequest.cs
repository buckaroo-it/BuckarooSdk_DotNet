namespace BuckarooSdk.Services.Emandates.DataRequest
{
	/// <summary>
	/// This action returns the status of an e-Mandate. When the e-Mandate is successful, the response also contains the ValidationReference. 
	/// The ValidationReference can be used in a (Simple) SEPA Direct Debit transaction as the Electronic Signature. It is advised to save this 
	/// value somewhere. However, you can provide only the MandateId / MandateReference in your (Simple) SEPA Direct Debit request and Buckaroo 
	/// will find the matching ValidationReference.
	/// </summary>
	public class EmandatesGetStatusRequest
	{
		/// <summary>
		/// Required
		/// The mandateId or “mandate reference“ is the id used to perform the SEPA direct debit calls in the future.
		/// </summary>
		public string MandateId { get; set; }
	}
}
