using System.Collections.Generic;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Data
{
	/// <summary>
	/// General data class, to hold a Request object and a list of services
	/// </summary>
	public class Data : RequestObject
	{
		internal IRequestObject DataRequestBase { get; private set; }

		internal Data(AuthenticatedRequest authenticatedRequest)
		{
			authenticatedRequest.Request.Endpoint = Constants.Settings.GatewaySettings.DataRequestEndPoint;
			this.AuthenticatedRequest = authenticatedRequest;
		}



		public ConfiguredTransaction SetBasicFields(IRequestObject basicFields)
		{
			this.DataRequestBase = basicFields;
			return new ConfiguredTransaction(this);
		}

		#region "Internal methods"
		internal void AddGlobal(string serviceName, List<RequestParameter> parameters, string action, string version = "1")
		{
			var global = new Global()
			{
				Name = serviceName,
				Action = action,
				Version = version,
				Parameters = parameters,
			};

			if (this.DataRequestBase.Services == null)
			{
				this.DataRequestBase.Services = new List<Service>();
			}
			this.DataRequestBase.Services.Add(global);
		}
		#endregion
	}
}
