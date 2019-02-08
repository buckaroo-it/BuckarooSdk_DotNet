namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    /// <summary>
    /// The idealrequest class, where the issuer of the request is specified.
    /// </summary>
    public class IdealPayRemainderRequest
    {
		/// <summary>
		/// Required
		/// 
		/// BIC code of the issuing bank of the consumer. Please refer to the list of banks in the general section for the list of BIC codes. 
		/// This information is required, but it is possible to let the customer fill it in on the Buckaroo checkout page. In that case, leave 
		/// the Issuer parameter out and add the basic parameter "ContinueOnIncomplete" with a value of 1. 
		/// 
		/// Use constants in BuckarooSdk.Services.Ideal.IdealIssuer
		/// </summary>
		public string Issuer { get; set; }
	}
}
