using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;



namespace BuckarooSdk.Connection
{
	/// <summary>
	/// Copyright 2016, Buckaroo B.V, Utrecht, The Netherlands.
	/// Use of copies permitted under the of terms of the GNU General Public Licence. 
	/// </summary>
	internal static class Connector
	{
		private static readonly string CheckoutUrl;// = ConfigurationManager.AppSettings["BuckarooCheckoutUrl"];
		private static readonly string TestCheckoutUrl; // = ConfigurationManager.AppSettings["BuckarooTestCheckoutUrl"];

		static Connector()
		{
			// get urls from config, or use default values
			CheckoutUrl = (CheckoutUrl ?? "https://checkout.buckaroo.nl").TrimEnd('/');
			TestCheckoutUrl = (TestCheckoutUrl ?? "https://testcheckout.buckaroo.nl").TrimEnd('/');

			// ensure urls are on the correct format
			ValidateUrls();
		}

		public static async Task<TResponse> SendRequest<TRequest, TResponse>(Request request, TRequest data, HttpRequestType requestType)
			where TResponse : IRequestResponse
		{
			try
			{
				// prepare serializer settings
				var settings = new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver(),
					Formatting = Formatting.Indented
				};

				var requestJson = String.Empty;
				try
				{
					requestJson = JsonConvert.SerializeObject(data, settings);
					//LOGGING
					request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.SerializedRequestJson(requestJson));
					request.BuckarooSdkLogger.HandleRawRequest(requestJson);
				}
				catch (JsonSerializationException exception)
				{
					request.BuckarooSdkLogger.AddErrorLogging(exception.ToString());
				}

				// live or test url
				var apiBaseAddress = request.IsLive ? CheckoutUrl : TestCheckoutUrl;

				// use BuckarooDelegatingHandler for HMAC auth
				var customDelegatingHandler = new BuckarooDelegatingHandler(request.WebsiteKey, request.ApiKey,
					request.Channel.ToString(), request.Culture.Name);
				var client = new HttpClient(customDelegatingHandler);

				//LOGGING
				request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.RequestTypeAndAddress(requestType,
					apiBaseAddress + request.Endpoint));

				HttpResponseMessage response;
				switch (requestType)
				{
					case HttpRequestType.Post:
						response =
							await
								client.PostAsync(apiBaseAddress + request.Endpoint,
									new StringContent(requestJson, Encoding.UTF8, "application/json")).ConfigureAwait(false);
						break;
					case HttpRequestType.Get:
						response = await client.GetAsync(apiBaseAddress + request.Endpoint).ConfigureAwait(false);
						break;
					default:
						request.BuckarooSdkLogger.AddErrorLogging(Constants.Logging.Messages.BadImplementation);
						throw new Exception(Constants.Logging.Messages.BadImplementation);
				}

				var responseJson = response.Content.ReadAsStringAsync().Result;

				// deserialize to response type
				try
				{
					var deserializedResponse = JsonConvert.DeserializeObject<TResponse>(responseJson);
					if (responseJson != null)
					{
						//Logging response
						request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.RequestSuccessful(true,
						responseJson));
						request.BuckarooSdkLogger.HandleRawResponse(responseJson);
					}

					request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.ResponseDeserialized);

					return deserializedResponse;
				}
				catch (JsonSerializationException exception)
				{
					request.BuckarooSdkLogger.AddErrorLogging(Constants.Logging.Messages.FailedSerializationResponseJson(responseJson) + exception);
				}

				return default(TResponse);

			}
			catch (Exception exception)
			{
				return default(TResponse);
			}
		}


		private static void ValidateUrls()
		{
			foreach (var url in new List<string>() { CheckoutUrl, TestCheckoutUrl })
			{
				Uri uriResult;
				var isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

				if (!isValidUrl)
				{
					throw new UriFormatException($"'{url}' is not a valid URI.");
				}
			}
		}
	}
}
