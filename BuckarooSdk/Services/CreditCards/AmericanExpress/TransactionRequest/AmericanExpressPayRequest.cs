namespace BuckarooSdk.Services.CreditCards.AmericanExpress.TransactionRequest
{
	public class AmericanExpressPayRequest
	{
		/// <summary>
		/// 
		/// </summary>
		public bool VerifyAddress { get; set; }	
		/// <summary>
		/// 
		/// </summary>
		public string CustomerIpAddress { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingMethodCode { get; set; }	
		/// <summary>
		/// 
		/// </summary>
		public string Recurring { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CustomerHttpBrowserType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CustomerHostServerName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string RecurringTimeType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int RecurringInterval { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingFirstName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingLastName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingStreet { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingHouseNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingPostalCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingCountryCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ShippingPhoneNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CustomerEmail { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BillingFirstName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BillingStreet { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BillingHouseNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BillingHouseNumberSuffix { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BillingPostalCode { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BillingPhoneNumber { get; set; }
	}
}
