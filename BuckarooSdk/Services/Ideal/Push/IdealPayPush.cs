using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class IdealPayPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.Ideal;

		/// <summary>
		/// This is the iDEAL transaction ID.
		/// </summary>
		public string Transactionid { get; set; }

		/// <summary>
		/// The international bank account number (iban code) of the bank of the consumer. Please note: This field is optional. 
		/// In some countries, banks are not allowed to provide this information to third parties.
		/// </summary>
		public string ConsumerIban { get; set; }

		/// <summary>
		/// The bank identifier (bic code) of the bank of the consumer. Please note: This field is optional. In some countries, 
		/// banks are not allowed to provide this information to third parties.
		/// </summary>
		public string ConsumerBic { get; set; }

		/// <summary>
		/// The beneficiary of the bank account from which the payment was made.
		/// </summary>
		public string ConsumerName { get; set; }

		/// <summary>
		/// The name of the issuer (bank) of the consumer.
		/// </summary>
		public string ConsumerIssuer { get; set; }
		
		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
