using ServiceNames = BuckarooSdk.Constants.Services.ServiceNames;

namespace BuckarooSdk.Services.CreditCards.Push
{
	public class CreditCardCancelAuthorizePush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.CreditCard;

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
