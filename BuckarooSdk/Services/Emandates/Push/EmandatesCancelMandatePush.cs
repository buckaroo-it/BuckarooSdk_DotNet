using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Emandates.Push
{
	public class EmandatesCancelMandatePush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.Emandates;

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

		/// <summary>
		/// Status of the e-mandate
		/// </summary>
		public string EmandateStatus { get; set; }

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}