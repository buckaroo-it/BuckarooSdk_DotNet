namespace BuckarooSdk.Services.BuckarooWallet
{
	public class BuckarooWalletGetBalanceResponse
	{
		public long CurrentBalance { get; set; }

		public string LastUpdated { get; set; }

		public int CurrentStatus { get; set; }

		public string WalletCurrency { get; set; }
	}
}
