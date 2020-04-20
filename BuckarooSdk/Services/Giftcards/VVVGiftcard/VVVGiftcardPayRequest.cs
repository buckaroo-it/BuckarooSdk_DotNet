namespace BuckarooSdk.Services.Giftcards.VVVGiftcard
{
	public class VVVGiftcardPayRequest
	{
		/// <summary>
		/// Maximum length = 20 numeric char
		/// </summary>
		public string IntersolveCardnumber { get; set; }

		/// <summary>
		/// Maximum length = 6 numeric char
		/// </summary>
		public string IntersolveValidationCode { get; set; }
	}
}
