namespace BuckarooSdk.Services.CreditCards.Request
{
	public class CreditCardPayRequest
	{
		/// <summary>
		/// Code chosen by merchant to recognize the customer of this transaction
		/// </summary>
		public string CustomerCode { get; set; }
	}
}
