namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
	/// <summary>
	/// The default action for iDEAL is Pay. This action requires as input the issuing bank of the consumer. 
	/// Upon receiving this input, the consumer will be redirected to the issuing bank for verification and confirmation of the payment. 
	/// An iDEAL payment has a lifetime of 15 minutes; this means that as soon as the consumer is redirected to the issuer, the payment
	/// must be completed within 15 minutes or it will expire. In the event that the consumer irregularly ends the payment process (for example
	/// by closing the browser window before returning to the webshop), the payment status will be retrieved from the acquirer as soon as 
	/// the 15 minute lifespan is expired and the merchant webshop is updated via a push response. It is therefore recommended to enable the 
	/// push response in the Payment Plaza when implementing iDEAL. A successful payment will include the BIC, the IBAN, the beneficiary of 
	/// the bank account from which the payment was made and the name of the selected issuer.
	/// </summary>
	public class IdealPayRequest
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
