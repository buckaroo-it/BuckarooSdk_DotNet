using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPal
{
    public class PayPalPayRemainderResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.PayPal;
        public string NoteText { get; set; }
        public string PayerStatus { get; set; }
        public string PayerCountry { get; set; }
        public string PayPalTransactionId { get; set; }
        public string PayerEmail { get; set; }
        public string PayerFirstName { get; set; }
        public string PayerMiddleName { get; set; }
        public string PayerLastName { get; set; }
    }
}
