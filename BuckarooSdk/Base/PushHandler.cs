using System;
using BuckarooSdk.DataTypes.Push;
using Newtonsoft.Json;

namespace BuckarooSdk.Base
{
    public class PushHandler
    {
	    public Push DeserializePush(string jsonString)
	    {
		    Push deserializeObject;

		    var secondLeftBraceIndex = jsonString.IndexOf("{", 1 + jsonString.IndexOf("{"));
		    var lastRightBraceIndex = jsonString.LastIndexOf("}");
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
				// TODO specify and log further
			    throw new Exception();
		    }

		    return deserializeObject;
	    }

	    public static TransactionPush DeserializeTransaction(string jsonString)
	    {
		    return JsonConvert.DeserializeObject<TransactionPush>(jsonString);
	    }

		 public static DataRequest DeserializeDataRequest(string jsonString)
	    {
		    return JsonConvert.DeserializeObject<DataRequest>(jsonString);
	    }
    }
}
