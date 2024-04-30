namespace BuckarooSdk.Services.iDin.TransactionRequest
{
    /// <summary>
    /// The verify action verifies if a consumer is 18 years or older. This includes the following information:
    /// Bin (unique ID per consumer, Is Eighteen or Older
    /// </summary>
    public class IDinVerifyRequest
    {
        /// <summary>
        /// Required
        /// BIC code of the issuing bank of the consumer. Please refer to the list of banks in the general section for the list of BIC codes. 
        /// In order to create a test iDIN verify request, you need to use the issuer "BANKNL2Y" instead of the actual bank.
        /// </summary>
        public string IssuerId { get; set; }
    }
}
