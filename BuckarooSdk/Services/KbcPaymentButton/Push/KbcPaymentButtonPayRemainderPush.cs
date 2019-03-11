namespace BuckarooSdk.Services.KbcPaymentButton.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class KbcPaymentButtonPayRemainderPush : ActionPush
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.KbcPaymentButton;

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
