using BuckarooSdk.DataTypes.ParameterGroups.Afterpay;
using System;

namespace BuckarooSdk.Services.Afterpay
{
	public class AfterpayPayRequest
	{
		public ParameterGroupCollection<Article> Articles { get; set; }
		public BillingCustomer BillingCustomer { get; set; }
		public ShippingCustomer ShippingCustomer { get; set; }
		public string MerchantImageUrl { get; set; }
		public string SummaryImageUrl { get; set; }
		public string BankAccount { get; set; }
		public string BankCode { get; set; }
	}
}