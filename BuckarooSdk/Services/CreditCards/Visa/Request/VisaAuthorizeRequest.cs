namespace BuckarooSdk.Services.CreditCards.Visa.Request
{
	public class VisaAuthorizeRequest
	{
		/// <summary>
		/// Code chosen by merchant to recognize the customer of this transaction
		/// </summary>
		public string CustomerCode { get; set; }
	}
}