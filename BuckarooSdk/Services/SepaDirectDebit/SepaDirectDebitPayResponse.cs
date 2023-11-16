using System;

namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitPayResponse : ActionResponse
    {
        public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.SepaDirectDebit;
        /// <summary>
        /// The date the mandate has been registered
        /// </summary>
        public DateTime MandateDate { get; set; }
        /// <summary>
        /// The type of direct debit that will be processed.
        /// </summary>
        public string DirectDebitType { get; set; }
        /// <summary>
        /// The date the mandate has been registered.
        /// </summary>
        public DateTime CollectDate { get; set; }
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
    }
}
