using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using BuckarooSdk.Services;
using Xunit;

namespace BuckarooSdk.UnitTests.Services
{
    /// <summary>
    /// The Buckaroo gateway parses request parameters against a fixed culture, and dates against the ISO 8601
    /// format documented per service (e.g. CreditManagement <c>InvoiceDate</c> "2020-02-10", In3
    /// <c>BirthDate</c> "1990-01-01", PayPerEmail <c>ExpirationDate</c> "2017-10-01"). These tests pin that the
    /// flattened wire value never depends on the culture of the machine running the SDK. Before the fix a
    /// nl-NL server flipped the decimal separator (12,5) and reordered day/month on <see cref="DateTime"/>
    /// parameters (3-6-1992), a genuine wire-format hazard for birth dates and invoice/due dates.
    /// </summary>
    public class ServiceHelperInvariantCultureTests
    {
        private sealed class DateRequest
        {
            public DateTime BirthDate { get; set; }
        }

        private sealed class RateRequest
        {
            public double Rate { get; set; }
        }

        private static string ValueUnderCulture(object request, string culture)
        {
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                return ServiceHelper.CreateServiceParameters(request).Single().Value;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }

        [Theory]
        [InlineData("nl-NL")]
        [InlineData("en-US")]
        [InlineData("de-DE")]
        public void DateOnly_SerializesAsIsoDate_RegardlessOfCulture(string culture)
        {
            // 3 June 1992. A culture-dependent ToString() renders this as "3-6-1992" (nl-NL) or "6/3/1992"
            // (en-US), reordering day and month; the documented ISO 8601 format removes that ambiguity.
            var value = ValueUnderCulture(new DateRequest { BirthDate = new DateTime(1992, 6, 3) }, culture);

            Assert.Equal("1992-06-03", value);
        }

        [Theory]
        [InlineData("nl-NL")]
        [InlineData("en-US")]
        public void DateWithTimeOfDay_SerializesAsIsoDateTime_RegardlessOfCulture(string culture)
        {
            var value = ValueUnderCulture(
                new DateRequest { BirthDate = new DateTime(2023, 12, 1, 14, 30, 15) }, culture);

            Assert.Equal("2023-12-01T14:30:15", value);
        }

        [Theory]
        [InlineData("nl-NL")]
        [InlineData("de-DE")]
        public void Double_UsesInvariantDecimalSeparator_RegardlessOfCulture(string culture)
        {
            // nl-NL and de-DE use a comma as the decimal separator; the wire format must use a dot.
            var value = ValueUnderCulture(new RateRequest { Rate = 12.5d }, culture);

            Assert.Equal("12.5", value);
        }
    }
}
