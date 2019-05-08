namespace BuckarooSdk.Services.PayPal
{
    public class PayPalPayRemainderRequest
    {
        public string ProductName { get; set; }
        public string BillingAgreementDescription { get; set; }
        public string PageStyle { get; set; }
        public string BuyerEmail { get; set; }
    }
}
