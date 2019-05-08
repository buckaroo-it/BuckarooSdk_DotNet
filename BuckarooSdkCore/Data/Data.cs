using System.Collections.Generic;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services;

namespace BuckarooSdk.Data
{
	/// <summary>
	/// General data class, to hold a Request object and a list of services
	/// </summary>
    public class Data
    {
        internal AuthenticatedRequest AuthenticatedRequest { get; set; }
		
        internal List<Service> Services { get; set; }
		internal DataBase DataRequestBase { get; private set; }

		internal Data(AuthenticatedRequest authenticatedRequest)
        {
			authenticatedRequest.Request.Endpoint = Constants.Settings.GatewaySettings.DataRequestEndPoint;
			this.AuthenticatedRequest = authenticatedRequest;
        }

	

		public ConfiguredDataRequest SetBasicFields(DataBase basicFields)
		{
			this.DataRequestBase = basicFields;
			return new ConfiguredDataRequest(this);
		}

		#region "Internal methods"
		/// <summary>
		/// Adding a service to the datarequest.
		/// </summary>
		/// <param name="serviceName">The name of the service</param>
		/// <param name="parameters">The list of service parameters</param>
		internal void AddService(string serviceName, List<RequestParameter> parameters, string action, string version = "1")
        {
            var service = new Service()
            {
                Name = serviceName,
				Action = action,
				Version = version,
				Parameters = parameters,
            };

			if(this.DataRequestBase.Services.ServiceList == null)
			{
				this.DataRequestBase.Services.ServiceList = new List<Service>();
			}
            this.DataRequestBase.Services.ServiceList.Add(service);
        }

		internal void AddGlobal(string serviceName, List<RequestParameter> parameters, string action, string version = "1")
		{
			var global = new Global()
			{
				Name = serviceName,
				Action = action,
				Version = version,
				Parameters = parameters,
			};

			if (this.DataRequestBase.Services.ServiceList == null)
			{
				this.DataRequestBase.Services.ServiceList = new List<Service>();
			}
			this.DataRequestBase.Services.ServiceList.Add(global);
		}
		#endregion
	}
}
