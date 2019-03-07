using System.Collections.Generic;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services;

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
		internal IRequestObject TransactionBase { get; private set; }

		/// <summary>
		/// Setter for the basic fields of the transaction.
		/// </summary>
		/// <param name="basicFields"></param>
		/// <returns> A configured transaction </returns>
		public ConfiguredTransaction SetBasicFields(IRequestObject basicFields)
		{
			this.TransactionBase = basicFields;
			return new ConfiguredTransaction(this);
		}

		/// <summary>
		/// Primary constructor
		/// </summary>
		internal TransactionRequest(AuthenticatedRequest authenticatedRequest)
		{
			authenticatedRequest.Request.Endpoint = Constants.Settings.GatewaySettings.TransactionRequestEndPoint;
			this.AuthenticatedRequest = authenticatedRequest;
		}

		#region "Internal methods"

		#endregion
	}
}
