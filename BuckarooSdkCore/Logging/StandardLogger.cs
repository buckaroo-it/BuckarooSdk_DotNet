using System.Text;

namespace BuckarooSdk.Logging
{
	public class StandardLogger : ILogger
	{
		private readonly StringBuilder _processLogger;
		private readonly StringBuilder _errorLogger;
		private readonly StringBuilder _warningLogger;
		internal string RawRequest;
		internal string RawResponse;

		public StandardLogger()
		{
			this._errorLogger = new StringBuilder();
			this._processLogger = new StringBuilder();
			this._warningLogger = new StringBuilder();
		}

		public void AddErrorLogging(string errorLog)
		{
			this._errorLogger.AppendLine(errorLog);
		}

		private int _processStep = 1;
		public void AddProcessLogging(string processLog)
		{
			this._processLogger.AppendLine($"{this._processStep}. {processLog}");
			this._processStep++;
		}

		public void AddWarningLogging(string warning)
		{
			this._warningLogger.AppendLine(warning);
		}

		public string GetErrorLog()
		{
			return this._errorLogger.ToString();
		}

		public string GetProcessLog()
		{
			return this._processLogger.ToString();
		}

		public string GetWarningLog()
		{
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
		}

		public void HandleRawResponse(string response)
		{
			this.RawResponse =  response;
		}

		public void Dispose()
		{
		}
	}
}
