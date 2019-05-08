namespace BuckarooSdk.Services.PayPal
{
    public class PayPalPayRequest
    {
        public string ProductName { get; set; }
        public string BillingAgreementDescription { get; set; }
        public string PageStyle { get; set; }
        public string BuyerEmail { get; set; }
    }
}
