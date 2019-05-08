namespace BuckarooSdk.Services.SimpleSepaDirectDebit
{
    public class SimpleSepaDirectDebitPayRequest
    {
		/// <summary>
		/// The account name of the customer.
		/// </summary>
        public string CustomerAccountName { get; set; }
		/// <summary>
		/// The mandate reference number.
		/// </summary>
        public string MandateReference { get; set; }
		/// <summary>
		/// The IBAN of the customers account.
		/// </summary>
		public string CustomerIban { get; set; }
		/// <summary>
		/// The BIC of the customers account.
		/// </summary>
		public string CustomerBic { get; set; }
		/// <summary>
		/// The date on which the Sepa Direct Debit needs to be collected.
		/// </summary>
        public string CollectDate { get; set; }
		/// <summary>
		/// The date the mandate has been registered.
		/// </summary>
        public string MandateDate { get; set; }
    }
}
