using System;
using System.IO;
using BuckarooSdk.Logging;

namespace BuckarooSdk.Tests.Constants
{
	public class CustomImplementationLogger : ILogger
	{
		public string LoggingFolder { get; set; }
		public string LoggingPath { get; set; }

		public CustomImplementationLogger()
		{
			this.LoggingFolder = DateTime.Now.Ticks.ToString();
			Directory.CreateDirectory($"{ TestSettings.LogBasePath }{this.LoggingFolder}");
		}

		public void AddProcessLogging(string processLog)
		{
		}

		public string GetProcessLog()
		{
			return "";
		}

		public void AddErrorLogging(string errorLog)
		{
			
		}

		public string GetErrorLog()
		{
			return "";
		}

		public void AddWarningLogging(string warning)
		{
			
		}

		public string GetWarningLog()
		{
			return "";
		}

		public string GetFullLog()
		{
			return "";
		}

		public string GetRawRequest()
		{
			return "";
		}

		public string GetRawResponse()
		{
			return "";
		}

		public void HandleRawRequest(string request)
		{
			File.WriteAllText($"{ TestSettings.LogBasePath }{this.LoggingFolder}\\rawrequest.json", request);
		}

		public void HandleRawResponse(string response)
		{
			File.WriteAllText($"{ TestSettings.LogBasePath }{this.LoggingFolder}\\rawresponse.json", response);
		}

		public void Dispose()
		{
			return;
		}
	}
}
