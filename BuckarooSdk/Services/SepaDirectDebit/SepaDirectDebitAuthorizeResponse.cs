namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitAuthorizeResponse : ActionResponse
    {
        public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.SepaDirectDebit;

        /// <summary>
        /// The BIC code for the customer bank account on which the direct debit will be performed.
        /// </summary>
        public string CustomerBic { get; set; }
        /// <summary>
        /// The BIC code for the customer bank account on which the direct debit will be performed.
        /// </summary>
        public string CustomerIban { get; set; }
        /// <summary>
        /// 	The mandate reference used for the direct debit.
        /// </summary>
        public string MandateReference { get; set; }
        /// <summary>
        /// 	The signing date of the mandate that was used.
        /// </summary>
        public string MandateDate { get; set; }
        /// <summary>
        /// 	The expected date on which the direct debit will be collected from the consumer account. This can differ from the input field collectdate, 
        /// 	due to a correction for the needed work days to process a direct debit.
        /// </summary>
        public string CollectDate { get; set; }
        /// <summary>
        /// 	Returns the type of direct debit that is going to be performed. Possible values: OnOff: A single directdebit.
        /// 	First: The first of a recurrent sequence. Recurring: The next direct debit in a recurring sequence.
        /// </summary>
        public string DirectDebitType { get; set; }
    }
}
