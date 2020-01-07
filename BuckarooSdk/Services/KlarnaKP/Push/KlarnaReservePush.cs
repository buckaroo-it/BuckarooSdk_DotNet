namespace BuckarooSdk.Services.KlarnaKP.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class KlarnaReservePush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.KlarnaKP;

		public string ReservationNumber { get; set; }

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
