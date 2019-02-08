namespace BuckarooSdk.Services.CreditCards.Request
{
	public class CreditCardAuthorizeRequest
	{
		/// <summary>
		/// States wether the transaction is recurring
		/// </summary>
		public string Recurring { get; set; }
		/// <summary>
		/// The customer code reference.
		/// </summary>
		public string CustomerCode { get; set; }
	}
}
