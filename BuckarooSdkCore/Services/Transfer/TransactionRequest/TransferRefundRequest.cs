namespace BuckarooSdk.Services.Transfer.TransactionRequest
{
    public class TransferRefundRequest
    {
		/// <summary>
		/// The IBAN of the customer that performed the transfer.
		/// </summary>
        public string CustomerIban { get; set; }
		/// <summary>
		/// The back account number of the account where the transfer is originated from.
		/// </summary>
        public string CustomerAccountnumber { get; set; }
		/// <summary>
		/// The kontonummber of the customer. As the name suggests, it is only required when performing
		/// a refund to a german bank.
		/// </summary>
        public string CustomerKontoNummer { get; set; }
		/// <summary>
		/// The back account number of the account where the transfer is originated from.
		/// </summary>
		public string CustomerAccountname { get; set; }
		/// <summary>
		/// The bankLeitszahl reference.
		/// </summary>
        public string CustomerBankleitzahl { get; set; }
		/// <summary>
		/// The BIC code of the bank where the payment originated from.
		/// </summary>
        public string CustomerBic { get; set; }
    }
}
