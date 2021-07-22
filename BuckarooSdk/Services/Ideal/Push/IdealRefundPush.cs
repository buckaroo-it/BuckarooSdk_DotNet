using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.Push
{
    /// <summary>
    /// iDEAL refund push action.
    /// </summary>
    public class IdealRefundPush : ActionPush
    {
        /// <inheritdoc/>
        public override ServiceNames ServiceNames => ServiceNames.Ideal;
    }
}
