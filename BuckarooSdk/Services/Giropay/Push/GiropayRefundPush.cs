using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Giropay.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class GiropayRefundPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.Giropay;

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
