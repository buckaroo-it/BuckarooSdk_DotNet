using System.Diagnostics;
using System.Text;

namespace BuckarooSdk.Logging
{
	public class ExtensiveLogger : ILogger
	{
		private readonly StringBuilder _processLogger = new StringBuilder();
		private readonly StringBuilder _errorLogger = new StringBuilder();
		private readonly StringBuilder _warningLogger = new StringBuilder();

		internal string RawRequest;
		internal string RawResponse;

		public void AddErrorLogging(string errorLog)
		{
			this._errorLogger.AppendLine(errorLog);
			Debug.WriteLine(errorLog);
		}

		public void AddProcessLogging(string processLog)
		{
			this._processLogger.AppendLine(processLog);
			Debug.WriteLine(processLog);
		}

		public void AddWarningLogging(string warning)
		{
			this._warningLogger.AppendLine(warning);
			Debug.WriteLine(warning);
		}

		public string GetErrorLog()
		{
			Debug.WriteLine("ErrorLog retrieved.");
			return this._errorLogger.ToString();
		}

		public string GetProcessLog()
		{
			Debug.WriteLine("ProcessLog retrieved.");
			return this._processLogger.ToString();
		}

		public string GetWarningLog()
		{
			Debug.WriteLine("WarningLog retrieved.");
			return this._warningLogger.ToString();
		}
		public string GetFullLog()
		{
			var fullLog = new StringBuilder()
				.AppendLine("\n---ERRORLOG---\n\n" + this._errorLogger + "\n\n---END ERRORLOG---")
				.AppendLine("\n---PROCESSLOG---\n\n" + this._processLogger + "\n\n---END PROCESSLOG---")
				.AppendLine("\n---WARNINGLOG---\n\n" + this._warningLogger + "\n\n---END WARNINGLOG---");

			return fullLog.ToString();
		}

		public string GetRawRequest()
		{
			return this.RawRequest;
		}

		public string GetRawResponse()
		{
			return this.RawResponse;
		}

		public void HandleRawRequest(string request)
		{
			this.RawRequest = request;
			Debug.WriteLine(request);
		}

		public void HandleRawResponse(string response)
		{
			this.RawResponse = response;
			Debug.WriteLine(response);
		}

		public void Dispose()
		{
		}
	}
}
