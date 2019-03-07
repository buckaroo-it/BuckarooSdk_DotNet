using System;

namespace BuckarooSdk.Services.PayPerEmail.Push
{
	public class PayPerEmailPaymentInvitationPush : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.PayPerEmail;
		public DateTime ExpirationDate { get; set; }
		public string PayLink { get; set; }
	}
}
