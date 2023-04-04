using System;

namespace BuckarooSdk.Services.Banking
{
    public class BankingPaymentOrderRequest
    {
        public string StructuredIssuerType { get; set; }
        public DateTime ProcessingDate { get; set; }
        public string Purpose { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string StructuredReference { get; set; }
        public string AccountHolderName { get; set; }
    }
}