namespace BuckarooSdk.Services.Klarna
{
	public class KlarnaPayRequest
	{
		public string ReservationNumber { get; set; }

		public int ArticleQuantity { get; set; }

		public string ArticleNumber { get; set; }

		public bool SendByMail { get; set; }

		public bool SendByEmail { get; set; }

		public bool PreserveReservation { get; set; }
	}
}
