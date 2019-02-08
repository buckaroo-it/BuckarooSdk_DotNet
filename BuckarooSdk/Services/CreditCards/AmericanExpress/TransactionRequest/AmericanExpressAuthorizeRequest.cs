namespace BuckarooSdk.Services.CreditCards.AmericanExpress.TransactionRequest
{
	public class AmericanExpressAuthorizeRequest
	{
		/// <summary>
		/// Boolean that states if the address of the custumer has been verified.
		/// </summary>
		public bool VerifyAddress { get; set; }
		/// <summary>
		/// IP address of the customer.
		/// </summary>
		public string CustomerIpAddress { get; set; }
		/// <summary>
		/// The method that is used for shipping. Amex has standards for this value.
		/// </summary>
		public string ShippingMethodCode { get; set; }
		/// <summary>
		/// States if the payment is a recurring payment.
		/// </summary>
		public string Recurring { get; set; }
		/// <summary>
		/// Browser type used by the customer. 
		/// </summary>
		public string CustomerHttpBrowserType { get; set; }
		/// <summary>
		/// Host server name used by the customer.
		/// </summary>
		public string CustomerHostServerName { get; set; }
		/// <summary>
		/// If the payment is a recurrent payment. It can be defined here in what sequence.
		/// </summary>
		public string RecurringTimeType { get; set; }
		public int RecurringInterval { get; set; }
		/// <summary>
		/// The first name stated on the shipping label
		/// </summary>
		public string ShippingFirstName { get; set; }
		/// <summary>
		/// The last name stated on the shipping label
		/// </summary>
		public string ShippingLastName { get; set; }
		/// <summary>
		/// The street where the product is shipped to.
		/// </summary>
		public string ShippingStreet { get; set; }
		/// <summary>
		/// The number of the residence where the product is shipped to.
		/// </summary>
		public string ShippingHouseNumber { get; set; }
		/// <summary>
		/// The postal code of the residence where the product is shipped to.
		/// </summary>
		public string ShippingPostalCode { get; set; }
		/// <summary>
		/// The country code of the country where the product is shipped to.
		/// </summary>
		public string ShippingCountryCode { get; set; }
		/// <summary>
		/// The phone number stated on the shipping information.
		/// </summary>
		public string ShippingPhoneNumber { get; set; }
		/// <summary>
		/// The customer's email address
		/// </summary>
		public string CustomerEmail { get; set; }
		/// <summary>
		/// The first name of customer, as stated on the invoice.
		/// </summary>
		public string BillingFirstName { get; set; }
		/// <summary>
		/// The street of the residence where the invoice is send to.
		/// </summary>
		public string BillingStreet { get; set; }
		/// <summary>
		/// The housenumber of the residence where the invoice is send to.
		/// </summary>
		public string BillingHouseNumber { get; set; }
		/// <summary>
		/// The housenumber suffix of the residence where the invoice is send to.
		/// </summary>
		public string BillingHouseNumberSuffix { get; set; }
		/// <summary>
		/// The postal code of the residence where the invoice is send to.
		/// </summary>
		public string BillingPostalCode { get; set; }
		/// <summary>
		/// The phone number as it is stated on the invoice
		/// </summary>
		public string BillingPhoneNumber { get; set; }
	}
}
