using BuckarooSdk.Connection;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.Push;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.Text;

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

        /// <summary>
        /// Deserializes a Buckaroo <see cref="Push"/> message.
        /// </summary>
        /// <param name="body">The body of the message as <see cref="Array"/> of <see cref="byte"/>.</param>
        /// <param name="requestUri">The <see cref="Uri"/> of the receiving endpoint of the Buckaroo <see cref="Push"/> message.</param>
        /// <param name="authorizationHeader">The Authorization header received with the <see cref="Push"/> message.</param>
        /// <returns>A <see cref="Push"/> message.</returns>
        /// <exception cref="AuthenticationException">If the HMAC Authorization header cannot be verified.</exception>
        public Push DeserializePush(byte[] body, Uri requestUri, string authorizationHeader)
		{
			var requestUriEncoded = WebUtility.UrlEncode($"{requestUri.Authority}{requestUri.PathAndQuery}").ToLower();

			var requestMethod = HttpMethod.Post.ToString();

			//calculate signature
			if (!this.SignatureCalculationService.VerifySignature(body, requestMethod, requestUriEncoded, this._apiKey, authorizationHeader))
			{
				throw new AuthenticationException();
			}

			// get content from request. 
			var bodyAsString = Encoding.UTF8.GetString(body);

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
            var result = JsonConvert.DeserializeObject<TransactionPush>(jsonString);
            var customParametersResult = JsonConvert.DeserializeObject<JObject>(jsonString);

            if (customParametersResult == null || result == null) return result;

			result.CustomParameters = ExtractCustomParameters(customParametersResult);

			return result;
        }

		private static DataRequest DeserializeDataRequest(string jsonString)
		{
			var result = JsonConvert.DeserializeObject<DataRequest>(jsonString);
            var customParametersResult = JsonConvert.DeserializeObject<JObject>(jsonString);

            if (customParametersResult == null || result == null) return result;

            result.CustomParameters = ExtractCustomParameters(customParametersResult);

            return result;
		}

        private static CustomParameters ExtractCustomParameters(JToken customParametersResult)
        {
            CustomParameters customParameters = null;

			foreach (var customParametersResultChild in customParametersResult.Children())
            {
                if (customParametersResultChild.Path != "CustomParameters") continue;

                customParameters = new CustomParameters
                {
                    List = new List<CustomParameter>()
                };

				foreach (var token in customParametersResultChild.Children().Children())
                {
                    customParameters.List.Add(new CustomParameter(token.SelectToken("Name")?.ToString(),
                        token.SelectToken("Value")?.ToString()));
                }
            }

            return customParameters;
		}
    }
}
