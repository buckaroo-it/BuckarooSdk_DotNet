using BuckarooSdk.DataTypes.ParameterGroups.Klarna;

namespace BuckarooSdk.Services.Klarna
{
	public class KlarnaPayRequest
	{
		public bool SendByEmail { get; set; }

		public bool PreserveReservation { get; set; }

		public string ReservationNumber { get; set; }

		public Article Article { get; set; }

		public bool SendByMail { get; set; }
	}
}
