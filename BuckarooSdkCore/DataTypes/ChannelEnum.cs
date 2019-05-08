namespace BuckarooSdk.DataTypes
{
	/// <summary>
	/// Enum with all channels from which transactions can be initiated.
	/// </summary>
    public enum ChannelEnum
    {
		#region channels

		/// <summary>
		/// The web channel.
		/// </summary>
		Web = 1,
		/// <summary>
		/// The POS channel.
		/// </summary>
        PointOfSale = 2,
		/// <summary>
		/// The batch file channel.
		/// </summary>
        BatchFile = 3,
		/// <summary>
		/// the Employee channel.
		/// </summary>
        Employee = 4,
		/// <summary>
		/// The callcenter channel.
		/// </summary>
        CallCenter = 5,
		/// <summary>
		/// The BSS channel.
		/// </summary>
        Bss = 6,
		/// <summary>
		/// The Buckaroo backoffice channel.
		/// </summary>
        BackOffice = 7,
		/// <summary>
		/// The internal checkout channel.
		/// </summary>
        InternalCheckout = 8

		#endregion
	}
}
