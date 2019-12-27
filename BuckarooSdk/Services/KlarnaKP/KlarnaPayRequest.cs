using BuckarooSdk.DataTypes.ParameterGroups.Klarna;

namespace BuckarooSdk.Services.KlarnaKP
{
	public class KlarnaPayRequest
	{
		public string ReservationNumber { get; set; }

		/// <summary>
		/// Only the Articlenumber and articlequantity are required, and only when the reservation is partially paid. 
		/// </summary>
		public Article Article { get; set; }

	}
}
