namespace BuckarooSdk.DataTypes
{
	/// <summary>
	/// A custom parameter is a name value pair that can be used to add custom data
	/// to a request.
	/// </summary>
    public class CustomParameter
    {
		/// <summary>
		/// The name of the parameter.
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// The value of the parameter.
		/// </summary>
        public string Value { get; set; }
    }
}
