namespace BuckarooSdk.Services.SimpleSepaDirectDebit
{
    public class SimpleSepaDirectDebitRefundRequest
    {
		/// <summary>
		/// The IBAN of the customers account
		/// </summary>
        public string CustomerIban { get; set; }
		/// <summary>
		/// The BIC of the customers account
		/// </summary>
        public string CustomerBic { get; set; }
		/// <summary>
		/// The account name of the customer
		/// </summary>
        public string CustomerAccountName { get; set; }
    }
}
