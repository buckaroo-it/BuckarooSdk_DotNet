namespace BuckarooSdk.Services.iDin.TransactionRequest
{
    /// <summary>
    /// iDIN is a service from the Dutch banks that allows consumers to identify themselves.
    /// iDIN allows consumers to use the same account across multiple platforms, greatly reducing the number of accounts they have to create and remember.
    /// </summary>
    public class IDinIdentifyRequest
    {
        /// <summary>
        /// Required
        /// BIC code of the issuing bank of the consumer. Please refer to the list of banks in the general section for the list of BIC codes. 
        /// In order to create a test iDIN request, you need to use the issuer "BANKNL2Y" instead of the actual bank.
        /// </summary>
        public string IssuerId { get; set; }
    }
}
