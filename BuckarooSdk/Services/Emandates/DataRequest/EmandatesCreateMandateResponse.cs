namespace BuckarooSdk.Services.Emandates.DataRequest
{
	/// <summary>
	/// The response contains a MandateID, that can be used as the MandateReference for (Simple) Sepa Direct Debits.
	/// </summary>
	public class EmandatesCreateMandateResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Emandates;

		/// <summary>
		/// The mandateId or “mandate reference” for the emandate, with this id you can retrieve the status from the GetStatus action 
		/// and perform SEPA direct debit transactions.
		/// </summary>
		public string MandateId { get; set; }

		/// <summary>
		/// If an error has occurred.
		/// </summary>
		public string IsError { get; set; }


	}
}
