namespace BuckarooSdk.DataTypes
{
	/// <summary>
	/// The IpAddress class contains all properties regarding the host IP address
	/// </summary>
    public class IpAddress
    {
		/// <summary>
		/// The type of Ip address, also known as the protocol type.
		/// </summary>
        public InternetProtocolVersion Type { get; set; }

		/// <summary>
		/// The actual Ip address
		/// </summary>
        public string Address { get; set; }
    }
}
