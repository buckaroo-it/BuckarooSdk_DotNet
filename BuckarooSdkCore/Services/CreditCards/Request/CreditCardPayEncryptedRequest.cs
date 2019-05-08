namespace BuckarooSdk.Services.CreditCards.Request
{
	public class CreditCardPayEncryptedRequest
	{
		/// <summary>
		/// The value of this parameter is the result of the "encryptCardData"-function of our Client Side Encryption SDK.
		/// </summary>
		public string EncryptedCardData { get; set; }
	}
}
