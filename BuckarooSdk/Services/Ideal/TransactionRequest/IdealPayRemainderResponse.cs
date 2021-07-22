using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    /// <summary>
    /// iDEAL Pay remainder response.
    /// </summary>
    public class IdealPayRemainderResponse : ActionResponse
    {
        /// <inheritdoc/>
        public override ServiceNames ServiceNames => ServiceNames.Ideal;

        /// <summary>
        /// This is the iDEAL transaction ID.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// The name of the issuer (bank) of the consumer.
        /// </summary>
        public string ConsumerIssuer { get; set; }
    }
}

