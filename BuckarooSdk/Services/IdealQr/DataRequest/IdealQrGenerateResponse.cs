namespace BuckarooSdk.Services.IdealQr.DataRequest
{
	public class IdealQrGenerateResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.IdealQr;

		public string QrImageUrl { get; set; }
	}
}
