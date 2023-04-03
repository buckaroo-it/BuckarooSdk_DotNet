namespace BuckarooSdk.Services.EMandate
{
    public class EMandateCancelMandateRequest
    {
        public string PurchaseId { get; set; }

        public string EMandateReason { get; set; }

        public string MandateId { get; set; }
    }
}