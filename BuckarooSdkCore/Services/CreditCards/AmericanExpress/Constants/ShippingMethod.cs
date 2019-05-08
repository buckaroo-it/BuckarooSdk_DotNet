namespace BuckarooSdk.Services.CreditCards.AmericanExpress.Constants
{
	public static class ShippingMethod
	{
		/// <summary>
		/// Delivery on the same day
		/// </summary>
		public const string SameDay = "01";
		/// <summary>
		/// Delivery method not specified
		/// </summary>
		public const string Unknown = "02";
		/// <summary>
		/// Priority delivery of 2 or 3 days
		/// </summary>
		public const string Priority = "03";
		/// <summary>
		/// Ground delivery for 4 or more days
		/// </summary>
		public const string Ground4OrMoreDays = "04";
		/// <summary>
		/// Delivery is done electronically
		/// </summary>
		public const string ElectronicDelivery = "05";

	}
}
