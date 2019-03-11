using BuckarooSdk.Base;

namespace BuckarooSdk.Transaction
{
	/// <summary>
	/// The actual transaction, that can only be obtained by defining a transaction request.
	/// </summary>
	public class TransactionRequest : RequestObject
	{
		/// <summary>
		/// The base transaction info
		/// </summary>
		internal IRequestObject TransactionBase { get; }

		/// <summary>
		/// Setter for the basic fields of the transaction.
		/// </summary>
		/// <param name="basicFields"></param>
		/// <returns> A configured transaction </returns>
		public ConfiguredTransaction SetBasicFields(IRequestObject basicFields)
		{
			this.RequestObjectBase = basicFields;
			return new ConfiguredTransaction(this);
		}

		/// <summary>
		/// Primary constructor
		/// </summary>
		internal TransactionRequest(AuthenticatedRequest authenticatedRequest, IRequestObject transactionBase = null)
		{
			TransactionBase = transactionBase;
			authenticatedRequest.Request.Endpoint = Constants.Settings.GatewaySettings.TransactionRequestEndPoint;
			this.AuthenticatedRequest = authenticatedRequest;
		}
	}
}
