namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    /// <summary>
    /// The idealrequest class, where the issuer of the request is specified.
    /// </summary>
    public class IdealPayRequest
    {
		/// <summary>
		/// Use constants in BuckarooSdk.Services.Ideal.IdealIssuer
		/// </summary>
		public string Issuer { get; set; }
	}
}
