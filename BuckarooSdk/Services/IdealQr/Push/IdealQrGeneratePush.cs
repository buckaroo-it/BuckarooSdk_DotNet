namespace BuckarooSdk.Services.IdealQr.Push
{
	public class IdealQrGeneratePush : ActionPush
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.IdealQr;
		public string QrImageUrl { get; set; }

		public override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
