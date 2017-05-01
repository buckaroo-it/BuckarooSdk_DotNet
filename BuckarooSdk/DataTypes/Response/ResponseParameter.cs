namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// The reponse parameter specifies the name and value of each response.
	/// </summary>
    public class ResponseParameter
    {
		/// <summary>
		/// The name of the response parameter.
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// The value of the response parameter.
		/// </summary>
        public string Value { get; set; }
    }
}