using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BuckarooSdk.Connection
{
	public class SignatureCalculationService
	{
		public string CalculateSignature(byte[] body, string requestHttpMethod, string requestTimeStamp, string nonce,
			string requestUri, string websiteKey, string apiKey)
		{
			return this.CalculateSignatureInternal(body, requestHttpMethod, requestTimeStamp, nonce, requestUri, websiteKey,
				apiKey);
		}

		public bool VerifySignature(byte[] body, string requestHttpMethod, string requestUri, string apiKey, string authorizationHeader)
		{
			var authorizationHeaderValues = authorizationHeader.Split(':', ' ');

			var nonce = authorizationHeaderValues[3];
			var requestTimeStamp = authorizationHeaderValues[4];
			var websiteKey = authorizationHeaderValues[1];

			var calculatedSignature =
				$"hmac {this.CalculateSignatureInternal(body, requestHttpMethod, requestTimeStamp, nonce, requestUri, websiteKey, apiKey)}";

			return string.Equals(calculatedSignature, authorizationHeader);
		}

		private string CalculateSignatureInternal(byte[] body, string requestHttpMethod, string requestTimeStamp,
			string nonce, string requestUri, string websiteKey, string apiKey)
		{
			var requestContentBase64String = string.Empty;

			if (body.Any())
			{
				var md5 = MD5.Create();

				// hashing the request body, any change in request body will result in different hash, we'll incure message integrity
				var requestContentHash = md5.ComputeHash(body);
				requestContentBase64String = Convert.ToBase64String(requestContentHash);
			}

			// creating the raw signature string
			var signatureRawData =
				$"{websiteKey}{requestHttpMethod}{requestUri}{requestTimeStamp}{nonce}{requestContentBase64String}";

			var secretKeyByteArray = Encoding.UTF8.GetBytes(apiKey);

			var signature = Encoding.UTF8.GetBytes(signatureRawData);

			using (var hmac = new HMACSHA256(secretKeyByteArray))
			{
				var signatureBytes = hmac.ComputeHash(signature);
				var requestSignatureBase64String = Convert.ToBase64String(signatureBytes);

				// setting the values in the Authorization header using custom scheme (hmac)
				return $"{websiteKey}:{requestSignatureBase64String}:{nonce}:{requestTimeStamp}";
			}
		}
	}
}
