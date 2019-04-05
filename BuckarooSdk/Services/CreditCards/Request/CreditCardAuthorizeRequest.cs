namespace BuckarooSdk.Services.CreditCards.Request
{
	public class CreditCardAuthorizeRequest
	{
		/// <summary>
		/// Code chosen by merchant to recognize the customer of this transaction
		/// </summary>
		public string CustomerCode { get; set; }
	}
}