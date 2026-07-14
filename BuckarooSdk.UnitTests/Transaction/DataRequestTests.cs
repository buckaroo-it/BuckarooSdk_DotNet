using System.Globalization;
using BuckarooSdk;
using BuckarooSdk.UnitTests.TestSupport;
using Xunit;

namespace BuckarooSdk.UnitTests.Transaction
{
    /// <summary>
    /// A data request and a transaction request are two different gateway operations that hit two
    /// different endpoints. The transaction endpoint is covered elsewhere; this pins the data-request
    /// endpoint so that accidentally swapping the two endpoint constants is caught.
    /// </summary>
    public class DataRequestTests
    {
        [Fact]
        public void DataRequest_TargetsDataRequestEndpoint()
        {
            var data = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"))
                .DataRequest();

            Assert.Equal("/json/DataRequest", data.AuthenticatedRequest.Request.Endpoint);
        }

        [Fact]
        public void DataRequest_EndpointDiffersFromTransactionEndpoint()
        {
            var authenticated = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"));

            var transactionEndpoint = authenticated.TransactionRequest().AuthenticatedRequest.Request.Endpoint;

            var dataAuthenticated = new SdkClient().CreateRequest()
                .Authenticate(TestCredentials.WebsiteKey, TestCredentials.ApiKey, false, new CultureInfo("nl-NL"));
            var dataEndpoint = dataAuthenticated.DataRequest().AuthenticatedRequest.Request.Endpoint;

            Assert.NotEqual(transactionEndpoint, dataEndpoint);
        }
    }
}
