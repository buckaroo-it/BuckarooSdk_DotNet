using System;

namespace BuckarooSdk.Services.CreditCards.AmericanExpress.Request
{
	public class AmericanExpressPayRequest
	{
		public int RecurringInterval { get; set; }

		/// <summary>
		/// This data element contains the two-character, Shipping Method Code (a.k.a., shipment-type code). Valid values include:
		/// 01 = Same Day
		/// 02 = Overnight / Next Day
		/// 03 = Priority, 2-3 days
		/// 04 = Ground, 4 or more days
		/// 05 = Electronic Delivery
		/// </summary>
		public string ShippingMethodCode { get; set; }

		public string Recurring { get; set; }

		/// <summary>
		/// This data element contains the Customer’s IP Address
		/// </summary>
		public string CustomerIPAddress { get; set; }

		public bool VerifyAddress { get; set; }

		public string CustomerHTTPBrowserType { get; set; }

		public string CustomerHostServerName { get; set; }

		public string RecurringTimeType { get; set; }

		public string CustomerCardName { get; set; }

		public string AmexCreditcardNumber { get; set; }

		public string CVV4 { get; set; }

		public string ShippingFirstName { get; set; }

		public string ShippingLastName { get; set; }

		public string ShippingStreet { get; set; }

		/// <summary>
		/// Credit card expiration date.
		/// </summary>
		public DateTime CardExpirationDate { get; set; }

		public string ShippingHouseNumber { get; set; }

		public string ShippingHouseNumberSuffix { get; set; }

		public string ShippingPostalCode { get; set; }

		public string ShippingCountryCode { get; set; }

		public string ShippingPhoneNumber { get; set; }

		/// <summary>
		/// The email address of the customer where the email needs to be send to.
		/// </summary>
		public string CustomerEmail { get; set; }

		public string BillingFirstName { get; set; }

		public string BillingLastName { get; set; }

		public string BillingStreet { get; set; }

		public string BillingHouseNumber { get; set; }

		public string BillingHouseNumberSuffix { get; set; }

		public string BillingPostalCode { get; set; }

		public string BillingPhoneNumber { get; set; }
	}
}
