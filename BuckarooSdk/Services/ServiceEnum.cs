namespace BuckarooSdk.Services
{
	public enum ServiceEnum
	{
		// Payment services
		Ideal,
		IdealProcessing,
		PayPal,
		MasterCard,
		Visa,
		Maestro,
		AmericanExpress,
		Transfer,
		SimpleSepaDirectDebit,
		Payconiq,
		Przelewy24,
		KbcPaymentButton,
	    EPS,

		// additional services
		CreditManagement,
		Emandates,
		Subscriptions,
		PayPerEmail,
		IdealQr,
		Dankort,
	}
}
