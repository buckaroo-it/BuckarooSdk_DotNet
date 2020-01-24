using System;
using BuckarooSdk.DataTypes.ParameterGroups.Afterpay;

namespace BuckarooSdk.Services.Afterpay
{

	public class AfterpayAuthorizeRequest
	{
		public ParameterGroupCollection<Article> Articles { get; set; }

		public BillingCustomer BillingCustomer { get; set; }
		public ShippingCustomer ShippingCustomer { get; set;  }
		public string MerchantImageUrl { get; set; }
		public string SummaryImageUrl { get; set; }
		public string BankAccount { get; set; }
		public string BankCode { get; set; }
	}
}
