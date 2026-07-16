using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.Logging;
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
		private static readonly string CheckoutUrl = "https://checkout.buckaroo.nl";
		private static readonly string TestCheckoutUrl = "https://testcheckout.buckaroo.nl";

		static Connector()
		{
			// ensure urls are on the correct format
			ValidateUrls();
		}

		public static async Task<TResponse> SendRequest<TRequest, TResponse>(Request request, TRequest data, HttpRequestType requestType, HttpMessageHandler transportHandler = null)
			where TResponse : IRequestResponse
		{
			// prepare serializer settings
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Formatting = Formatting.Indented
			};

			string requestJson;
			try
			{
				requestJson = JsonConvert.SerializeObject(data, settings);
				//LOGGING
				request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.SerializedRequestJson(requestJson));
				request.BuckarooSdkLogger.HandleRawRequest(requestJson);
			}
			catch (JsonException exception)
			{
				request.BuckarooSdkLogger.AddErrorLogging(exception.ToString());
				throw new BuckarooException("The request could not be serialized to JSON.", exception);
			}

			// live or test url
			var apiBaseAddress = request.IsLive ? CheckoutUrl : TestCheckoutUrl;

			HttpResponseMessage response = null;
			string responseJson = null;
			try
			{
				// use BuckarooDelegatingHandler for HMAC auth
				var customDelegatingHandler = new BuckarooDelegatingHandler(request.WebsiteKey, request.ApiKey,
					request.Channel.ToString(), request.Culture.Name, transportHandler);
				var client = new HttpClient(customDelegatingHandler);

				//LOGGING
				request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.RequestTypeAndAddress(requestType,
					apiBaseAddress + request.Endpoint));

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
						throw new BuckarooException(Constants.Logging.Messages.BadImplementation);
				}

				responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			}
			catch (BuckarooException)
			{
				throw;
			}
			catch (Exception exception)
			{
				// The gateway could not be reached, the response signature failed to validate, etc. Surface a
				// meaningful, catchable exception instead of returning null and letting the caller dereference it.
				request.BuckarooSdkLogger.AddErrorLogging(exception.ToString());
				throw new BuckarooException("The request to the Buckaroo gateway could not be completed.", exception);
			}

			// A non-success status (for example a 429 when requests are rate limited or blocked by a web
			// application firewall) does not carry a payment-engine response body, so it is turned into a
			// BuckarooException carrying the status code rather than being parsed into a null response.
			if (!response.IsSuccessStatusCode)
			{
				var statusMessage = $"The Buckaroo gateway returned HTTP status {(int)response.StatusCode} ({response.StatusCode}). " +
					"This usually means the request was rate limited or blocked before it reached the payment engine. " +
					$"Response body: {responseJson}";
				request.BuckarooSdkLogger.AddErrorLogging(statusMessage);
				throw new BuckarooException(response.StatusCode, statusMessage, responseJson);
			}

			// deserialize to response type
			try
			{
				var deserializedResponse = JsonConvert.DeserializeObject<TResponse>(responseJson);
				if (deserializedResponse == null)
				{
					throw new BuckarooException(response.StatusCode,
						"The Buckaroo gateway returned an empty or unrecognised response.", responseJson);
				}

				//Logging response
				request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.RequestSuccessful(true, responseJson));
				request.BuckarooSdkLogger.HandleRawResponse(responseJson);
				request.BuckarooSdkLogger.AddProcessLogging(Constants.Logging.Messages.ResponseDeserialized);

				return deserializedResponse;
			}
			catch (BuckarooException)
			{
				throw;
			}
			catch (JsonException exception)
			{
				request.BuckarooSdkLogger.AddErrorLogging(Constants.Logging.Messages.FailedSerializationResponseJson(responseJson) + exception);
				throw new BuckarooException(response.StatusCode,
					"The Buckaroo gateway response could not be deserialized.", responseJson);
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
