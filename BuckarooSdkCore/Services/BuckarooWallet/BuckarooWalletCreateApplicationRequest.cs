namespace BuckarooSdk.Services.BuckarooWallet
{

	public class BuckarooWalletCreateApplicationRequest
	{
		public string CustomerLastName { get; set; }

		public string CustomerFirstName { get; set; }

		public string CustomerEmail { get; set; }

		public string Walletid { get; set; }

		public string CustomerInitials { get; set; }

		public int CurrentStatus { get; set; }

		public long CreationBalance { get; set; }
	}
}
