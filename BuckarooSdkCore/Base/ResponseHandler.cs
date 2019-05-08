using System;
using System.Collections.Generic;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.Services;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Base
{
	[Obsolete]
    public class ResponseHandler
    {
        public void HandleResponse(RequestResponse transaction)
        {

        }

        public static List<DataTypes.Response.Service> RetrieveServices(RequestResponse transactionResponse)
        {
            var services = transactionResponse.GetServices();

            return new List<DataTypes.Response.Service>();
        }

        internal static ServiceNames ServiceSwitch(List<ServiceNames> services)
        {
            var specificService = new ServiceNames();
            foreach (var service in services)
            {
                switch (service)
                {
                    case ServiceNames.Ideal:
                        specificService = ServiceNames.Ideal;
                        break;
                }
            }
            return specificService;
        }
    }
}
