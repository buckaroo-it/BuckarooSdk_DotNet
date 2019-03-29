using System;

namespace BuckarooSdk.Services.BuckarooVoucher
{
	public class BuckarooVoucherCreateApplicationResponse
	{
		public long CreationBalance { get; set; }

		public DateTime ValidFrom { get; set; }

		public DateTime ValidUntil { get; set; }

		public string VoucherCode { get; set; }
	}
}
