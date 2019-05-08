using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.DataTypes.Response;

namespace BuckarooSdk.Transaction.Cancel
{
	public class ConfiguredCancelTransaction
	{
		internal CancelTransaction CancelTransaction { get; set; }

		public ConfiguredCancelTransaction(CancelTransaction cancelTransaction)
		{
			this.CancelTransaction = cancelTransaction;
		}

		/// <summary>
        /// Execute the request, a post to the Buckaroo Payment Engine is prepared and send.
        /// </summary>
        /// <returns>General TransactionResponse object is returned</returns>
        public RequestResponse Execute()
        {
            return Connection.Connector.SendRequest<IRequestBase, RequestResponse>(this.CancelTransaction.Request.Request, this.CancelTransaction.CancelTransactionBase, HttpRequestType.Post).Result;
        }
	}
}
