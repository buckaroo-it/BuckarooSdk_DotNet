using BuckarooSdk.Constants;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace BuckarooSdk.Connection
{
	internal class BuckarooDelegatingHandler : DelegatingHandler
	{
		private SignatureCalculationService SignatureCalculationService { get; }

		internal BuckarooDelegatingHandler(string websiteKey, string apiKey, string channel, string culture)
		{
			this._websiteKey = websiteKey;
			this._apiKey = apiKey;
			this._channel = channel;
			this._culture = culture;
			this._software = JsonConvert.SerializeObject(new Settings.Software());

			this.InnerHandler = new HttpClientHandler();
			this.SignatureCalculationService = new SignatureCalculationService();
		}



		//Obtained from the server earlier
		private readonly string _websiteKey;
		private readonly string _apiKey;
		private readonly string _channel;
		private readonly string _culture;
		private readonly string _software;

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
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
			var content = await request.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var authorizationHeaderString = this.SignatureCalculationService.CalculateSignature(content, requestHttpMethod, requestTimeStamp, nonce, requestUri, this._websiteKey, this._apiKey);

			request.Headers.Authorization = new AuthenticationHeaderValue("hmac", authorizationHeaderString);
			// set other headers
			request.Headers.Add("culture", this._culture);
			request.Headers.Add("channel", this._channel);
			request.Headers.Add("software", this._software);

			response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

			if (!await this.ValidateResponse(response, request.Method.ToString(), requestUri).ConfigureAwait(false))
			{
				throw new AuthenticationException();
			}

			return response;
		}

		protected async Task<bool> ValidateResponse(HttpResponseMessage response, string requestMethod, string requestUri)
		{
			response.Headers.TryGetValues("Authorization", out var authorizationResponse);
			var actualHeader = authorizationResponse.ToList().First();
			var body = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

			return this.SignatureCalculationService.VerifySignature(body, requestMethod, requestUri, this._apiKey, actualHeader);
		}
	}
}
