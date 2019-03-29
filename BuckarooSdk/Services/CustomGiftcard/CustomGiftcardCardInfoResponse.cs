using System;

namespace BuckarooSdk.Services.CustomGiftcard
{
	public class CustomGiftcardCardInfoResponse
	{
		public DateTime CardIssueDate { get; set; }

		public DateTime CardExpiryDate { get; set; }

		public DateTime CardUpdateDate { get; set; }

		public string CurrencyCode { get; set; }

		public long CardBalance { get; set; }
	}
}
