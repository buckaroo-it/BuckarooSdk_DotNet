namespace BuckarooSdk.Services.AfterpayDigiaccept.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class AfterpayDigiacceptAuthorizePush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.AfterpayDigiaccept;

		/// <summary>
		/// The name of the issuer (bank) of the consumer.
		/// </summary>
		public string ConsumerIssuer { get; set; }

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
