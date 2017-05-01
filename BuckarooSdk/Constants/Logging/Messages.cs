using System;
using System.Collections.Generic;
using System.Linq;
using BuckarooSdk.DataTypes;

namespace BuckarooSdk.Constants.Logging
{
	internal static class Messages
	{
		internal const string RequestCreated = "A new request is created";

		internal const string RequestSerialized = "The request is successfuly serialized to JSON";

		internal const string ResponseDeserialized = "The reponse is succesfully deserialized";

		internal const string BadImplementation =
			"Request type is badly implemented in the buckaroo SDK. Please contact Buckaroo";

		private const string SecretKeyToShort = "The secret key that is used in your implementation is shorter than" +
												"recommended. We recommend a secret key of at least 10 characters.";

		internal static string RequestTypeAndAddress(HttpRequestType requestType, string requestAddress)
		{
			return $"The request type is: {requestType} \nThe request address is: {requestAddress}";
		}

		internal static string SerializedRequestJson(string requestJson)
		{
			return $"The serialized request in JSON format is: \n{requestJson} \n";
		}

		internal static string SerializedResponseJson(string responseJson)
		{
			return $"The returned response in JSON format is: \n{responseJson} \n";
		}

		internal static string FailedSerializationResponseJson(string responseJson)
		{
			return $"The returned response in JSON format could not be serialized: \n{responseJson} \n";
		}

		internal static string RequestSuccessful(bool successful, string jsonResponse)
		{
			return successful ? $"Response is returned properly \n{SerializedResponseJson(jsonResponse)}\n" : "Response is not returned properly";
		}

		internal static string RequestAuthenticated(string[] values)
		{
			return $"Requst authenticated with values:{CreateValueListLog(values)}";
		}

		private static string CreateValueListLog(IEnumerable<String> values)
		{
			return values.Aggregate("", (current, value) => current + $"\n{value} ");
		}

		internal static string CheckSecretKey(string secretKey)
		{
			return secretKey.Length < 10 ? SecretKeyToShort : string.Empty;
		}
	}
}
