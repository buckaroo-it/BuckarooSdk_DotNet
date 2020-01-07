namespace BuckarooSdk.Services.KlarnaKP.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class KlarnaCancelReservationPush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.KlarnaKP;

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
