using System;

namespace BuckarooSdk.Logging
{
	/// <summary>
	/// Logging interface used by the Buckaroo SDK. The SDK provides one implementation of this interface. If functionality is
	/// required that is not supported by this implementation, a custom logger can be made and used, as long
	/// as the custom logger implements this interface.
	/// </summary>
	public interface ILogger : IDisposable
	{
		void AddProcessLogging(string processLog);
		string GetProcessLog();
		void AddErrorLogging(string errorLog);
		string GetErrorLog();
		void AddWarningLogging(string warning);
		string GetWarningLog();
		string GetFullLog();
		string GetRawRequest();
		string GetRawResponse();
		void HandleRawRequest(string request);
		void HandleRawResponse(string response);
	}
}
