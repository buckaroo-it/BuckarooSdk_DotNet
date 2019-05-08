using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.IdealQr.DataRequest
{
	public class IdealQrGenerateResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.IdealQr;

		public string QrImageUrl { get; set; }
	}
}
