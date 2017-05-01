using System.Runtime.InteropServices.ComTypes;

namespace BuckarooSdk.Services.PayPal
{
    public class PayPalPayRecurrentResponse : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.PayPal;
        public string PayerStatus { get; set; }
        public string PayerCountry { get; set; }
        public string PayerEmail { get; set; }
        public string PaypalTransactionID { get; set; }
        public string PayerFirstname { get; set; }
        public string PayerMiddlename { get; set; }
        public string PayerLastname { get; set; }
    }
}
