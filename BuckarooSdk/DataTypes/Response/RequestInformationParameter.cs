namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// All data corresponding for a request information parameter
	/// </summary>
    public class RequestInformationParameter
    {
		/// <summary>
		/// The name of the request information parameter
		/// </summary>
        public string Name { get; set; }
		/// <summary>
		/// The data type of the parameter
		/// </summary>
        public DataType DataType { get; set; }
		/// <summary>
		/// the maximum length of the parameter
		/// </summary>
        public int MaxLength { get; set; }
		/// <summary>
		/// Specifies whether the parameter is required for the request.
		/// </summary>
        public bool Required { get; set; }
		/// <summary>
		/// The description of the parameter.
		/// </summary>
        public string Description { get; set; }
    }
}