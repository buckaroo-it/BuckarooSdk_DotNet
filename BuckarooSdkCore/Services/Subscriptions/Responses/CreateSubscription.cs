using BuckarooSdk.DataTypes.ParameterGroups.Subscriptions;

namespace BuckarooSdk.Services.Subscriptions.Responses
{
	/// <summary>
	/// https://dev.buckaroo.nl/AdditionalServices/Description/subscriptions#createsubscription
	/// 
	/// CreateSubscription is a data request that activates a customer subscription in the Buckaroo Payment Engine. In this call you 
	/// can state which subscription needs to be activated for which customer (debtor). Additional debtor information can be provided with 
	/// the request if needed. Debtor parameters are based on the AddOrUpdateDebtor action as defined in the Buckaroo Credit Management Service.
	///
	/// When it comes to determining the subscription payment method, there are three ways to perform this request:
	/// 
	/// 1.	It is optional to provide the original transaction key of a previously succesfully performed transaction (this can be iDEAL, PayPal, 
	///		Creditcard (Authorize) or Sepa Direct Debit) that has the attribute "StartRecurrent = True". This way the payment method used for that 
	///		transaction will be used for the subscription payments. Use the parameter "OriginalTransactionKey", which is a basic parameter, not a 
	///		(Subscription) service specific parameter.
	/// 
	/// 2.	It is optional to provide the SEPA bank account details of the customer (including mandate reference), so that the subscription will 
	///		use Sepa Direct Debit payments.
	/// 
	/// 3.	It is possible to perform the request without reference to a transaction or bank account details. In this case the first invoice will 
	///		trigger a payment invitation (PayperEmail) to the customer. If a payment via the PayPerEmail is performed, the used payment method will 
	///		be also used for the following subscription payments. 
	/// 
	/// Important note: when for some reason a subscription payment fails, or when the payment is being reversed (chargeback), a payment reminder 
	/// for that invoice can be sent to the customer (Credit Management service). Like mentioned in point 3, the used payment method for that 
	/// payment will then be used for the following subscription payments. This way it is possible that a payment method changes during a subscription.
	/// </summary>
	public class CreateSubscription
	{
		/// <summary>
		/// The unique code of the subscription configuration.
		/// </summary>
		public string ConfigurationCode { get; set; }
		public RatePlan RatePlan { get; set; }
		public RatePlanCharge RatePlanCharge { get; set; }
		/// <summary>
		/// The term start day determines when a subscription term starts. The value depends on the chosen invoice interval: weekly: 1 to 7, monthly/2 
		/// monthly/quarterly/half yearly/yearly: 1 to 31. Only provide this parameter if it differs from the default value in provided rate plan.
		/// </summary>
		public int TermsStartDay { get; set; }
		/// <summary>
		/// The term start month determines when a subscription term starts. The value depends on the chosen invoice interval: 2 monthly: 1 to 2. 
		/// Quarterly: 1 to 3. Half yearly: 1 to 6. Yearly: 1 to 12. Only provide this parameter if it differs from the default value in provided rate plan.
		/// </summary>
		public int TermsStartMonth { get; set; }
		/// <summary>
		/// To bill in advance or in arrears of a period. InAdvance = 1, InArrears = 2. Only provide this parameter if it differs from the default value 
		/// in provided rate plan
		/// </summary>
		public int BillingTiming { get; set; }

	}
}