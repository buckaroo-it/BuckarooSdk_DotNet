namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitPayRequest
    {
        public string CollectDate { get; set; }
        public string CustomerAccountName { get; set; }
        public string CustomerIBAN { get; set; }
        public string CustomerBic { get; set; }
        public string MandateReference { get; set; }
        public string MandateDate { get; set; }
    }
}
