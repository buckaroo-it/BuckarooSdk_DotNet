using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.Error
{
	/// <summary>
	/// All errors regarding the request. All errors are ordered by category. 
	/// </summary>
    public class RequestErrors
    {
		/// <summary>
		/// A list of channel related errors
		/// </summary>
        public List<ChannelError> ChannelErrors = new List<ChannelError>();
		/// <summary>
		/// A list of service related errors
		/// </summary>
        public List<ServiceError> ServiceErrors = new List<ServiceError>();
		/// <summary>
		/// A list of action related errors
		/// </summary>
        public List<ActionError> ActionErrors = new List<ActionError>();
		/// <summary>
		/// A list of parameter related errors
		/// </summary>
        public List<ParameterError> ParameterErrors = new List<ParameterError>();
		/// <summary>
		/// A list of custom parameter related errors
		/// </summary>
        public List<CustomParameterError> CustomParameterErrors = new List<CustomParameterError>();
    }
}