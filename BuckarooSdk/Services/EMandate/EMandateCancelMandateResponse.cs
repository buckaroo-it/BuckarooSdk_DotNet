namespace BuckarooSdk.Services.EMandate
{
    internal class EMandateCancelMandateResponse
    {
        public string MandateId { get; set; }
        public string ErrorResponseMessage { get; set; }
        public bool IsError { get; set; }
    }
}
