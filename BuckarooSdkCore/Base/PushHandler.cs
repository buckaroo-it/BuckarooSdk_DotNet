using BuckarooSdk.DataTypes.Push;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Text;
using BuckarooSdk.Connection;

namespace BuckarooSdk.Base
{
	public class PushHandler
	{
		private SignatureCalculationService SignatureCalculationService { get; }
		private readonly string _apiKey;

		public PushHandler(string apiKey)
		{
			this._apiKey = apiKey;
			this.SignatureCalculationService = new SignatureCalculationService();
		}

		public Push DeserializePush(byte[] body, string requestUri, string authorizationHeader)
		{
			var requestUriEncoded = WebUtility.UrlEncode(requestUri)?.ToLower();

			var requestMethod = HttpMethod.Post.ToString();

			// get content from request. 
			var bodyAsString = Encoding.UTF8.GetString(body);

			//calculate signature
			if (!this.SignatureCalculationService.VerifySignature(body, requestMethod, requestUri, this._apiKey, authorizationHeader))
			{
				throw new AuthenticationException();
			}

			return this.DeserializePush(bodyAsString);
		}

		private Push DeserializePush(string jsonString)
		{
			Push deserializeObject;

			var secondLeftBraceIndex = jsonString.IndexOf("{", 1 + jsonString.IndexOf("{", StringComparison.Ordinal), StringComparison.Ordinal);
			var lastRightBraceIndex = jsonString.LastIndexOf("}", StringComparison.Ordinal);
			var pushtype = jsonString.Substring(0, secondLeftBraceIndex);

			// Take everything that is between the second opening brace and the last closing brace (excluding the latter)
			var content = jsonString.Substring(secondLeftBraceIndex, lastRightBraceIndex - secondLeftBraceIndex);

			if (pushtype.Contains(PushType.TransactionPush))
			{
				return DeserializeTransaction(content);
			}

			if (pushtype.Contains(PushType.DataRequestPush))
			{
				deserializeObject = DeserializeDataRequest(content);
			}
			else
			{
				throw new SerializationException();
			}

			return deserializeObject;
		}

		private static TransactionPush DeserializeTransaction(string jsonString)
		{
			return JsonConvert.DeserializeObject<TransactionPush>(jsonString);
		}

		private static DataRequest DeserializeDataRequest(string jsonString)
		{
			return JsonConvert.DeserializeObject<DataRequest>(jsonString);
		}
	}
}
