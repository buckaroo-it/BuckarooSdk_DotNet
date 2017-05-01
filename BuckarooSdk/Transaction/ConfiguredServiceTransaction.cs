using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.Logging;

namespace BuckarooSdk.Transaction
{
	/// <summary>
	/// The transaction that is configured for execution
	/// </summary>
    public class ConfiguredServiceTransaction
    {
        internal TransactionRequest BaseTransaction { get;}

		internal ConfiguredServiceTransaction(TransactionRequest transactionRequest)
        {
            this.BaseTransaction = transactionRequest;
        }

        /// <summary>
        /// Execute the request, a post to the Buckaroo Payment Engine is prepared and sent.
        /// </summary>
        /// <returns>General TransactionResponse object is returned</returns>
        public RequestResponse Execute()
        {
            var response = Connection.Connector.SendRequest<IRequestBase, RequestResponse>(this.BaseTransaction.AuthenticatedRequest.Request, this.BaseTransaction.TransactionBase, HttpRequestType.Post).Result;

			// relocate logger from request to response
			response.BuckarooSdkLogger = this.BaseTransaction.AuthenticatedRequest.Request.BuckarooSdkLogger;

			return response;
        }

		public ConfiguredAdditionalTransaction AddAdditionalService() 
		{
			return new ConfiguredAdditionalTransaction(this.BaseTransaction);
		}

	    public ILogger GetLogger()
	    {
		    return this.BaseTransaction.AuthenticatedRequest.Request.BuckarooSdkLogger;
	    }
    }
}