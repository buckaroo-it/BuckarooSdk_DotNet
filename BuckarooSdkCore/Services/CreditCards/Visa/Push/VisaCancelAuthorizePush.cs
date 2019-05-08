namespace BuckarooSdk.Services.CreditCards.Visa.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class VisaCancelAuthorizePush : ActionPush
	{
		public override BuckarooSdk.Constants.Services.ServiceNames ServiceNames => BuckarooSdk.Constants.Services.ServiceNames.Visa;

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
