using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Sofort.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class SofortPayRecurrentPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.Sofort;

		

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
