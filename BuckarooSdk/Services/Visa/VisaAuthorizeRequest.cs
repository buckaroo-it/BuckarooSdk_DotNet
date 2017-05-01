namespace BuckarooSdk.Services.Visa
{
    public class VisaAuthorizeRequest
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
