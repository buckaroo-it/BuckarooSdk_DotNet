namespace BuckarooSdk.Services.Giftcards.HuisTuinGiftcard
{
	public class HuisTuinGiftcardPayRequest
	{
		/// <summary>
		/// Maximum length = 20 numeric char
		/// </summary>
		public string TCSCardnumber { get; set; }

		/// <summary>
		/// Maximum length = 6 numeric char
		/// </summary>
		public string TCSValidationCode { get; set; }
	}
}
