namespace BuckarooSdk.Services.CreditCards.MasterCard.Request
{
	public class MasterCardPayRequest
	{
		/// <summary>
		/// Code chosen by merchant to recognize the customer of this transaction
		/// </summary>
		public string CustomerCode { get; set; }
	}
}