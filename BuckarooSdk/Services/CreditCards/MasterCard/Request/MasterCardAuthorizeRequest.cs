namespace BuckarooSdk.Services.CreditCards.MasterCard.Request
{
	public class MasterCardAuthorizeRequest
	{
		/// <summary>
		/// Code chosen by merchant to recognize the customer of this transaction
		/// </summary>
		public string CustomerCode { get; set; }
	}
}