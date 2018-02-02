using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BuckarooSdk.Constants;
using Newtonsoft.Json;

namespace BuckarooSdk.Connection
{
	internal class BuckarooDelegatingHandler : DelegatingHandler
	{
		internal BuckarooDelegatingHandler(string websiteKey, string apiKey, string channel, string culture)
		{
			this._websiteKey = websiteKey;
			this._apiKey = apiKey;
			this._channel = channel;
			this._culture = culture;
			this._software = JsonConvert.SerializeObject(new Settings.Software());

			this.InnerHandler = new HttpClientHandler();
		}

		//Obtained from the server earlier
		private readonly string _websiteKey;
		private readonly string _apiKey;
		private readonly string _channel;
		private readonly string _culture;
		private readonly string _software;

		protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpResponseMessage response = null;


			var requestUri = WebUtility.UrlEncode(request.RequestUri.Authority + request.RequestUri.PathAndQuery).ToLower();

			var requestHttpMethod = request.Method.Method;

			// calculate UNIX time
			var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
			var timeSpan = DateTime.UtcNow - epochStart;
			var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

			// create random nonce for each request
			var nonce = Guid.NewGuid().ToString("N");

			// checking if the request contains body, usually will be null with HTTP GET and DELETE
			var content = request.Content;
			var authorizationHeaderString = await this.CalculateSignature(content, requestHttpMethod, requestTimeStamp, nonce, requestUri);

			request.Headers.Authorization = new AuthenticationHeaderValue("hmac", authorizationHeaderString);
			// set other headers
			request.Headers.Add("culture", this._culture);
			request.Headers.Add("channel", this._channel);
			request.Headers.Add("software", this._software);

			response = await base.SendAsync(request, cancellationToken);

			IEnumerable<string> authorizationResponse;
			response.Headers.TryGetValues("Authorization", out authorizationResponse);

			if (!await this.ValidateResponse(response, request.Method.ToString(), requestUri))
			{
				throw new AuthenticationException();
			}
			
			return response;
		}

		private async Task<string> CalculateSignature(HttpContent content, string requestHttpMethod, string requestTimeStamp, string nonce, string requestUri)
		{
			var requestContentBase64String = string.Empty;

			if (content != null)
			{
				var contentBytes = await content.ReadAsByteArrayAsync();
				var md5 = MD5.Create();

				// hashing the request body, any change in request body will result in different hash, we'll incure message integrity
				var requestContentHash = md5.ComputeHash(contentBytes);
				requestContentBase64String = Convert.ToBase64String(requestContentHash);

				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			}

			// creating the raw signature string
			string signatureRawData = string.Format("{0}{1}{2}{3}{4}{5}", this._websiteKey, requestHttpMethod, requestUri,
				requestTimeStamp, nonce, requestContentBase64String);

			var secretKeyByteArray = Encoding.UTF8.GetBytes(this._apiKey);

			var signature = Encoding.UTF8.GetBytes(signatureRawData);

			using (var hmac = new HMACSHA256(secretKeyByteArray))
			{
				var signatureBytes = hmac.ComputeHash(signature);
				var requestSignatureBase64String = Convert.ToBase64String(signatureBytes);

				// setting the values in the Authorization header using custom scheme (hmac)
				return  $"{this._websiteKey}:{requestSignatureBase64String}:{nonce}:{requestTimeStamp}";
			}
		}

		protected async Task<bool> ValidateResponse(HttpResponseMessage response, string requestMethod, string requestUri)
		{
			IEnumerable<string> authorizationResponse;
			response.Headers.TryGetValues("Authorization", out authorizationResponse);

			if (authorizationResponse == null)
			{
				return false;
			}

			var actualHeader = authorizationResponse.ToList().First();
			var actualAuthHeaderValues = actualHeader.Split(':',' ');

			var nonce = actualAuthHeaderValues[3];
			var unixTimeStamp = actualAuthHeaderValues[4];

			var calculatedSignature = await this.CalculateSignature(response.Content, requestMethod, unixTimeStamp, nonce, requestUri);

			var calculatedHeader = $"hmac {calculatedSignature}";

			return string.Equals(calculatedHeader, actualHeader);
		}
	}
}
