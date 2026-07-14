namespace BuckarooSdk.UnitTests.TestSupport
{
    /// <summary>
    /// Obviously-fake, non-functional credentials used purely to drive the deterministic,
    /// network-free code paths (signature calculation, request building). These are NOT real
    /// Buckaroo keys and never authenticate against any environment.
    /// </summary>
    public static class TestCredentials
    {
        public const string WebsiteKey = "5CA1AB1E0000000000000000000000000000BEEF";
        public const string ApiKey = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
    }
}
