using System.Collections.Generic;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services;

namespace BuckarooSdk.Transaction
{
	/// <summary>
	/// The actual transaction, that can only be obtained by defining a transaction request.
	/// </summary>
    public class TransactionRequest
	{
        internal AuthenticatedRequest AuthenticatedRequest { get; set; }

		/// <summary>
		/// The base transaction info
		/// </summary>
        internal TransactionBase TransactionBase { get; private set; }
        
		/// <summary>
		/// Setter for the basic fields of the transaction.
		/// </summary>
		/// <param name="basicFields"></param>
		/// <returns> A configured transaction </returns>
        public ConfiguredTransaction SetBasicFields(TransactionBase basicFields)
        {
            this.TransactionBase = basicFields;
            return new ConfiguredTransaction(this);
        }

		/// <summary>
		/// Primary constructor
		/// </summary>
		/// <param name="authenticatedRequest"></param>
		internal TransactionRequest(AuthenticatedRequest authenticatedRequest)
        {
            authenticatedRequest.Request.Endpoint = Constants.Settings.GatewaySettings.TransactionRequestEndPoint;
            this.AuthenticatedRequest = authenticatedRequest;
        }

        #region "Internal methods"
        internal void AddService(string serviceName, List<RequestParameter> parameters, string action, string version = "1")
        {
            var service = new Service()
            {
                Name = serviceName,
                Action = action,
                Version = version,
                Parameters = parameters
            };

            this.TransactionBase.Services.ServiceList.Add(service);
        }

		internal void AddAdditionalService(string serviceName, List<RequestParameter> parameters, string action, string version = "1")
		{
			var service = new Service()
			{
				Name = serviceName,
				Action = action,
				Version = version,
				Parameters = parameters
			};

			this.TransactionBase.Services.ServiceList.Add(service);
		}
		#endregion
	}
}
