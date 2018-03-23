using System;
using System.Collections.Generic;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.Services;

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

        internal static ServiceEnum ServiceSwitch(List<ServiceEnum> services)
        {
            var specificService = new ServiceEnum();
            foreach (var service in services)
            {
                switch (service)
                {
                    case ServiceEnum.Ideal:
                        specificService = ServiceEnum.Ideal;
                        break;
                }
            }
            return specificService;
        }
    }
}
