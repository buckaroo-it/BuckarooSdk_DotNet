using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.SimpleSepaDirectDebit
{
    public class SimpleSepaDirectDebitRefundResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.SimpleSepaDirectDebit;

		/// <summary>
		/// The account name of the customer
		/// </summary>
        public string CustomerAccountName { get; set; }
		/// <summary>
		/// The IBAN of the customers account
		/// </summary>
		public string CustomerIban { get; set; }
		/// <summary>
		/// The BIC of the customers account
		/// </summary>
		public string CustomerBic { get; set; }
    }
}
