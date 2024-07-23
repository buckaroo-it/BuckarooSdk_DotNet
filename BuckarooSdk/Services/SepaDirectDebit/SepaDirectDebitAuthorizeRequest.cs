namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitAuthorizeRequest
    {
        /// <summary>
        /// The name of the accountholder for the account on which the direct debit should be performed.
        /// </summary>
        public string CustomerAccountName { get; set; }
        /// <summary>
        /// The IBAN for the customer bank account on which the direct debit will be performed.
        /// </summary>
        public string CustomerIban { get; set; }
        /// <summary>
        /// The BIC code for the customer bank account on which the direct debit will be performed.
        /// </summary>
        public string CustomerBic { get; set; }
        /// <summary>
        /// The mandate reference for the SEPA Direct Debit. It is possible to provide your own unique reference, or use the mandateID from an Emandate,
        /// In any case, the MandateReference should always begin with a three digit prefix which can be found in the General Information on the Buckaroo 
        /// Plaza (My Buckaroo > General).
        /// </summary>
        public string MandateReference { get; set; }
        /// <summary>
        /// The signing date of the mandate (dd-mm-yyyy).
        /// </summary>
        public string MandateDate { get; set; }
    }
}
