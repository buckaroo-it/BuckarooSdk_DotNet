namespace BuckarooSdk.Services.KbcPaymentButton.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class KbcPaymentButtonRefundPush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.KbcPaymentButton;

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
