using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.Push
{
    /// <summary>
    /// iDEAL Pay remainder push action.
    /// </summary>
    public class IdealPayRemainderPush : ActionPush
    {
        /// <inheritdoc/>
        public override ServiceNames ServiceNames => ServiceNames.Ideal;

        /// <summary>
        /// The international bank account number (iban code) of the bank of the consumer. Please note: This field is optional. 
        /// In some countries, banks are not allowed to provide this information to third parties.
        /// </summary>
        public string ConsumerIban { get; set; }

        /// <summary>
        /// The bank identifier (bic code) of the bank of the consumer. Please note: This field is optional. In some countries, 
        /// banks are not allowed to provide this information to third parties.
        /// </summary>
        public string ConsumerBic { get; set; }

        /// <summary>
        /// The beneficiary of the bank account from which the payment was made.
        /// </summary>
        public string ConsumerName { get; set; }

        /// <summary>
        /// The name of the issuer (bank) of the consumer.
        /// </summary>
        public string ConsumerIssuer { get; set; }
    }
}
