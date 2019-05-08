namespace BuckarooSdk.Services.OnlineGiroLite.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class OnlineGiroLitePaymentInvitationPush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.OnlineGiroLite;
		
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
