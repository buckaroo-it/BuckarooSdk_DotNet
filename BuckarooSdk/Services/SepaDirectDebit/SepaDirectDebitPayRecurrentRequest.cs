namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitPayRecurrentRequest
    {
        /// <summary>
        /// The date (dd-mm-yyyy) on which the direct debit should be collected from the consumer account. 
        /// Important note: if combined with Credit Management, the collect date should always precede the due date of the invoice, since you don't want to trigger 
        /// a reminder step before debiting the customer. If however, the collect date is accidentally set after the due date, then the first reminder step will be postponed
        /// till the collect date, but only if it's set within 14 days after the due date. 
        /// If it's set further than that, then our system will perform another check after 14 days and so on.
        /// </summary>
        public string CollectDate { get; set; }
    }
}
