using System;

namespace BuckarooSdk.Services.PayPerEmail
{
    public class PayPerEmailPaymentInvitationResponse : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.PayPerEmail;
        public DateTime ExpirationDate { get; set; }
        public string PayLink { get; set; }
    }
}
