using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Transaction.Cancel
{
	public class CancelTransaction
	{
		internal AuthenticatedRequest Request { get; set; }

		internal CancelTransactionBase CancelTransactionBase { get; set; }

		public CancelTransaction(AuthenticatedRequest authenticatedRequest)
		{
			this.Request = authenticatedRequest;
		}

		public ConfiguredCancelTransaction CancelMultiple(CancelTransactionBase cancelTransaction)
		{
			this.CancelTransactionBase = cancelTransaction;
			this.Request.Request.Endpoint += $"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}{Constants.Settings.GatewaySettings.CancelMultipleEndPoint}";
			return new ConfiguredCancelTransaction(this);
		}
	}
}
