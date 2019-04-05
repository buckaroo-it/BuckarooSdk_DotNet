namespace BuckarooSdk.Services.BuckarooWallet
{
	public class BuckarooWalletUpdateRequest
	{
		public string CustomerEmail { get; set; }

		public string CustomerInitials { get; set; }

		public int CurrentStatus { get; set; }

		public string Walletid { get; set; }

		public string CustomerLastName { get; set; }

		public string CustomerFirstName { get; set; }
	}
}
