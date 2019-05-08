using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Transfer.TransactionRequest
{
    public class TransferPayResponse : ActionResponse
    {
	    public override ServiceNames ServiceNames => ServiceNames.Transfer;
		/// <summary>
		/// The name of the account where the transfer is originated from.
		/// </summary>
        public string AccountHolderName { get; set; }
		/// <summary>
		/// The back account number of the account where the transfer is originated from.
		/// </summary>
        public string BankAccount { get; set; }
		/// <summary>
		/// The IBAN of the customer that performed the transfer.
		/// </summary>
        public string Iban { get; set; }
		/// <summary>
		/// The BIC code of the bank where the payment originated from.
		/// </summary>
        public string Bic { get; set; }
		/// <summary>
		/// The country of origin of the customer.
		/// </summary>
        public string AccountHolderCountry { get; set; }
		/// <summary>
		/// The bankLeitszahl reference.
		/// </summary>
        public string Bankleitzahl { get; set; }
		/// <summary>
		/// The city where the accountholder lives in.
		/// </summary>
        public string AccountHolderCity { get; set; }
    }
}
