using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.IdealQr.Push
{
	public class IdealQrGeneratePush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.IdealQr;
		public string QrImageUrl { get; set; }

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
