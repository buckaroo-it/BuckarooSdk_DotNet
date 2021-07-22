namespace BuckarooSdk.Services.Ideal.Constants
{
    /// <summary>
    /// iDEAL output parameters.
    /// </summary>
    public enum OutputParameters
    {
        /// <summary>
        /// The bank identifier (bic code) of the bank of the consumer. Please note: This field is optional. In some countries, 
        /// banks are not allowed to provide this information to third parties.
        /// </summary>
        ConsumerBic,

        /// <summary>
        /// The beneficiary of the bank account from which the payment was made.
        /// </summary>
        ConsumerName,

        /// <summary>
        /// The name of the issuer (bank) of the consumer.
        /// </summary>
        ConsumerIssuer,

        /// <summary>
        /// The international bank account number (iban code) of the bank of the consumer. Please note: This field is optional. 
        /// In some countries, banks are not allowed to provide this information to third parties.
        /// </summary>
        ConsumerIban,
    }
}
