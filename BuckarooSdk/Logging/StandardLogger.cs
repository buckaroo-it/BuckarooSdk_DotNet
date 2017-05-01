using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.Constants.Logging;
using Microsoft.SqlServer.Server;

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

		public void AddProcessLogging(string processLog)
		{
			this._processLogger.AppendLine(processLog);
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
				.AppendLine("---ERRORLOG---\n\n" + this._errorLogger + "\n\n---END ERRORLOG---")
				.AppendLine("---PROCESSLOG---\n\n" + this._processLogger + "\n\n---END PROCESSLOG---")
				.AppendLine("---WARNINGLOG---" + this._warningLogger + "\n\n---END WARNINGLOG---");

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
