using System;

namespace BuckarooSdk.Services.BuckarooVoucher
{
	public class BuckarooVoucherCreateApplicationRequest
	{
		public DateTime ValidUntil { get; set; }

		public long CreationBalance { get; set; }

		public int UsageType { get; set; }

		public DateTime ValidFrom { get; set; }

		public string GroupReference { get; set; }
	}
}
