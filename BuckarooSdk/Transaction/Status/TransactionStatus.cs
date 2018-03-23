using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Transaction.Status
{
	public class TransactionStatus
	{
		internal AuthenticatedRequest Request { get; set; }
		internal TransactionStatusBase TransactionStatusBase { get; set; }

		public TransactionStatus(AuthenticatedRequest request)
		{
			this.Request = request;
		}

		public ConfiguredTransactionStatus Status(string transactionKey)
		{
			this.Request.Request.Endpoint += ($"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}" +
											$"{Constants.Settings.GatewaySettings.StatusEndPoint}" +
											$"{transactionKey}");
			
			return new ConfiguredTransactionStatus(this);
		}

		public ConfiguredTransactionStatus Statuses(TransactionStatusBase transactionStatusBase)
		{
			this.TransactionStatusBase = transactionStatusBase;
			this.Request.Request.Endpoint += Constants.Settings.GatewaySettings.TransactionRequestEndPoint + 
				Constants.Settings.GatewaySettings.StatusesEndPoint;
			return new ConfiguredTransactionStatus(this);
		}
	}
}
