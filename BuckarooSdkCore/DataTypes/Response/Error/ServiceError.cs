namespace BuckarooSdk.DataTypes.Response.Error
{
	/// <summary>
	/// An error regarding a service related problem.
	/// </summary>
	public class ServiceError
    {
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