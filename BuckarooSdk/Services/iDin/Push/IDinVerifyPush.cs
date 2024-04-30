using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.iDin.Push
{
    public class IDinVerifyPush : ActionPush
    {
        public override ServiceNames ServiceNames => ServiceNames.IDin;

        /// <summary>
        /// The BIN (Bank Identification Number) of the consumer.
        /// </summary>
        public string ConsumerBin { get; set; }

        /// <summary>
        /// Indicates whether the customer is eighteen years old or older.
        /// </summary>
        public bool IsEighteenOrOlder { get; set; }
    }
}
