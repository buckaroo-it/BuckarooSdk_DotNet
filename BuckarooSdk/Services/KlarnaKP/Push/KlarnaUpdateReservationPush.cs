namespace BuckarooSdk.Services.KlarnaKP.Push
{
	public class KlarnaUpdateReservationPush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.KlarnaKP;

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
