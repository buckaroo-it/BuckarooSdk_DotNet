using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.iDin.Push
{
    public class IDinLoginPush : ActionPush
    {
        public override ServiceNames ServiceNames => ServiceNames.IDin;

        /// <summary>
        /// The BIN (Bank Identification Number) of the consumer.
        /// </summary>
        public string ConsumerBin { get; set; }
    }
}
