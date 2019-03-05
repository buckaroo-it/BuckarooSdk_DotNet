using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.TransactionRequest
{

	public class IdealRefundResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.Ideal;

		/// <summary>
		/// The international bank account number (iban code) of the bank of the consumer. Please note: This field is optional. In some countries, 
		/// banks are not allowed to provide this information to third parties.
		/// </summary>
		public string CustomerIban { get; set; }

		/// <summary>
		/// The bank identifier (bic code) of the bank of the consumer. Please note: This field is optional. In some countries, banks are not 
		/// allowed to provide this information to third parties.
		/// </summary>
		public string CustomerBic { get; set; }

		/// <summary>
		/// The beneficiary of the bank account from which the payment was made.
		/// </summary>
		public string CustomerAccountName { get; set; }
	}
}
