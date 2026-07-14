using Xunit;
using SdkStatus = BuckarooSdk.Constants.Status;

namespace BuckarooSdk.UnitTests.Constants
{
    /// <summary>
    /// The numeric status codes are a shared contract with the Buckaroo gateway that consumers branch on
    /// (e.g. <c>if (push.Status.Code.Code == Status.Success)</c>). Pinning them here turns an accidental
    /// edit of the contract into a failing test rather than a silent production incident.
    /// </summary>
    public class StatusCodeTests
    {
        [Theory]
        [InlineData(190, SdkStatus.Success)]
        [InlineData(490, SdkStatus.Failed)]
        [InlineData(491, SdkStatus.FailedValidation)]
        [InlineData(492, SdkStatus.TechnicalError)]
        [InlineData(690, SdkStatus.Declined)]
        [InlineData(790, SdkStatus.PendingInput)]
        [InlineData(791, SdkStatus.PendingProcessing)]
        [InlineData(792, SdkStatus.WaitingForConsumer)]
        [InlineData(793, SdkStatus.OnHold)]
        [InlineData(890, SdkStatus.CanceledByUser)]
        [InlineData(891, SdkStatus.CanceledByMerchant)]
        public void StatusCode_MatchesGatewayContract(int expected, int actual)
        {
            Assert.Equal(expected, actual);
        }
    }
}
