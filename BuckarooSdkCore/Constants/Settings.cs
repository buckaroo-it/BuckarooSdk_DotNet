using System;
using System.Reflection;

namespace BuckarooSdk.Constants
{
	internal class Settings
	{
		internal class GatewaySettings
		{
			/// <summary>
			/// Main endpoints
			/// </summary>
			internal const string TransactionRequestEndPoint = "/json/transaction";
			internal const string DataRequestEndPoint = "/json/DataRequest";

			/// <summary>
			/// Additional endpoints
			/// </summary>
			internal const string SpecificationsEndpoint = "/specifications";
			internal const string SpecificationEndpoint = "/specification/";
			internal const string StatusesEndPoint = "/statuses";
			internal const string StatusEndPoint = "/status/";
			internal const string InvoiceInfosEndPoint = "/invoiceinfos";
			internal const string InvoiceInfoEndPoint = "/invoiceinfo/";
			internal const string RefundInfosEndPoint = "/refundinfos";
			internal const string RefundInfoEndPoint = "/refundinfo/";
			internal const string CancelMultipleEndPoint = "/cancelmultiple";
		}

		internal class Software
		{
			public string PlatformName = ".NET";
			public string PlatformVersion = Environment.Version.ToString();
			public string ModuleSupplier = "Buckaroo";
			public string ModuleName = "BuckarooSdk";
			public string ModuleVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
	}
}
