namespace BuckarooSdk.DataTypes.Response.Error
{

	/// <summary>
	/// An error regarding a parameter related problem.
	/// </summary>
	public class ParameterError
    {
		/// <summary>
		/// Service used when the error occured.
		/// </summary>
		public string Service { get; set; }
		/// <summary>
		/// The action that was performed when the error occured.
		/// </summary>
		public string Action { get; set; }
		/// <summary>
		/// The name of the error.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// The actual error.
		/// </summary>
		public string Error { get; set; }
		/// <summary>
		/// The message containing details of the error.
		/// </summary>
		public string ErrorMessage { get; set; }
	}
}