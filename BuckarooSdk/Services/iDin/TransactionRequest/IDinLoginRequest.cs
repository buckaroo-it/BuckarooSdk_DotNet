namespace BuckarooSdk.Services.iDin.TransactionRequest
{
    /// <summary>
    /// The login call returns a unique ID for each consumer. This returns the following information: Bin (unique ID per consumer)
    /// </summary>
    public class IDinLoginRequest
    {
        /// <summary>
        /// Required
        /// BIC code of the issuing bank of the consumer. Please refer to the list of banks in the general section for the list of BIC codes. 
        /// In order to create a test iDIN request, you need to use the issuer "BANKNL2Y" instead of the actual bank.
        /// </summary>
        public string IssuerId { get; set; }
    }
}
