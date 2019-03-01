using System;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.PayPerEmail
{
	public class PayPerEmailPaymentInvitationResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.PayPerEmail;
        public DateTime ExpirationDate { get; set; }
        public string PayLink { get; set; }
    }
}
