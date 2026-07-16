using System;
using System.Net;

namespace BuckarooSdk.Logging
{
	/// <summary>
	/// Raised when a request to the Buckaroo gateway cannot be completed or the gateway responds with a
	/// non-success HTTP status (for example a 429 when requests are rate limited or blocked by a web
	/// application firewall). Inspect <see cref="StatusCode"/> and <see cref="ResponseBody"/> to decide how
	/// to react (e.g. back off and retry on a 429).
	/// </summary>
	public class BuckarooException : Exception
	{
		/// <summary>
		/// The HTTP status code returned by the gateway, when the failure originated from an HTTP response.
		/// Null when the request never produced a response (e.g. a transport or serialization failure).
		/// </summary>
		public HttpStatusCode? StatusCode { get; }

		/// <summary>
		/// The raw response body returned by the gateway, when available.
		/// </summary>
		public string ResponseBody { get; }

		/// <summary>
		/// Retained for backwards compatibility with earlier SDK versions.
		/// </summary>
		public string ErrorMessage { get; set; }

		public BuckarooException()
		{
			this.ErrorMessage = "unknown exception";
		}

		public BuckarooException(string errorMessage)
			: base(errorMessage)
		{
			this.ErrorMessage = errorMessage;
		}

		public BuckarooException(string errorMessage, Exception innerException)
			: base(errorMessage, innerException)
		{
			this.ErrorMessage = errorMessage;
		}

		public BuckarooException(HttpStatusCode statusCode, string errorMessage, string responseBody = null)
			: base(errorMessage)
		{
			this.StatusCode = statusCode;
			this.ResponseBody = responseBody;
			this.ErrorMessage = errorMessage;
		}
	}
}
