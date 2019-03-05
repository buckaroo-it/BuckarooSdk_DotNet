namespace BuckarooSdk.Services.CreditCards.MasterCard.Request
{
	public class MasterCardAuthorizeEncryptedRequest
	{
		/// <summary>
		/// The value of this parameter is the result of the "encryptCardData"-function of our Client Side Encryption SDK.
		/// </summary>
		public string EncryptedCardData { get; set; }
	}
}
