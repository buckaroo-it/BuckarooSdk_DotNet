using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Emandates.DataRequest
{
	public class EmandatesModifyMandateResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Emandates;

		/// <summary>
		/// The mandateId or “mandate reference”, with this id you can retrieve the status from the GetStatus action and perform 
		/// SEPA direct debit transactions
		/// </summary>
		public string MandateId { get; set; }

		/// <summary>
		/// If an error has occurred
		/// </summary>
		public string IsError { get; set; }
	}
}
