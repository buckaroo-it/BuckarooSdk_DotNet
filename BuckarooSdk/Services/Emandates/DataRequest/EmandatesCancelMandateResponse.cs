namespace BuckarooSdk.Services.Emandates.DataRequest
{
	public class EmandatesCancelMandateResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.Emandates;

		/// <summary>
		/// The mandateId or “mandate reference”
		/// </summary>
		public string MandateId { get; set; }

		/// <summary>
		/// The error response message, empty if no error has occurred
		/// </summary>
		public string ErrorResponseMessage { get; set; }

		/// <summary>
		/// If an error has occurred
		/// </summary>
		public string IsError { get; set; }
	}
}