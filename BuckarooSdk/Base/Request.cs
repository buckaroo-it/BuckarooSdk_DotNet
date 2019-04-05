using System.Globalization;
using BuckarooSdk.Logging;

namespace BuckarooSdk.Base
{
	/// <summary>
	/// 
	/// </summary>
	public class Request
	{
		internal ILogger BuckarooSdkLogger { get; set; }

		internal string Endpoint { get; set; }

		/// <summary>
		/// The website key of the website that the request belongs to
		/// </summary>
		internal string WebsiteKey { get; private set; }

		/// <summary>
		/// The api key
		/// </summary>
		internal string ApiKey { get; private set; }

		/// <summary>
		/// A boolean that states wether the request is for live or test purposes
		/// </summary>
		internal bool IsLive { get; private set; }

		/// <summary>
		/// The channel of the request. The options that can be used are specified in a channel enumeration. 
		/// </summary>
		internal DataTypes.ChannelEnum Channel { get; private set; }

		/// <summary>
		/// The request culture.
		/// </summary>
		internal CultureInfo Culture { get; private set; }

		public Request(ILogger logger)
		{
			this.BuckarooSdkLogger = logger;
			this.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.RequestCreated);
		}

		/// <summary>
		/// This method sets the properties within the request that are necessary 
		/// for authentication of the request.
		/// </summary>
		/// <param name="websiteKey"></param>
		/// <param name="apiKey"></param>
		/// <param name="isLive"></param>
		/// <returns> An AuthenticatedRequest</returns>
		public AuthenticatedRequest Authenticate(string websiteKey, string apiKey, bool isLive,
			CultureInfo culture, DataTypes.ChannelEnum channel = DataTypes.ChannelEnum.Web)
		{
			this.WebsiteKey = websiteKey;
			this.ApiKey = apiKey;
			this.IsLive = isLive;
			this.Culture = culture;
			this.Channel = channel;

			var valuesUsedByClient = new string[]
			{
				$"websiteKey: {websiteKey}",
				$"apiKey: {apiKey}",
				$"isLive: {isLive}",
				$"culture: {culture}",
				$"channel: {channel}",
			};

			//logging
			this.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.RequestAuthenticated(valuesUsedByClient));
			this.BuckarooSdkLogger.AddWarningLogging(Constants.Logging.Messages.CheckSecretKey(apiKey));

			return new AuthenticatedRequest(this);
		}
		
		
	}
}
