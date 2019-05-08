using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Transaction.InvoiceInfo
{
	public class TransactionInvoiceInfo
	{
		internal AuthenticatedRequest Request { get; set; }
		internal TransactionInvoiceInfoBase TransactionInvoiceInfoBase { get; set; }
		public TransactionInvoiceInfo(AuthenticatedRequest request)
		{
			this.Request = request;
		}

		public ConfiguredTransactionInvoiceInfo SpecificInvoiceInfo(string transactionKey)
		{
			this.Request.Request.Endpoint += $"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}" +
											$"{Constants.Settings.GatewaySettings.InvoiceInfoEndPoint}" +
											$"{transactionKey}";

			return new ConfiguredTransactionInvoiceInfo(this);
		}

		public ConfiguredTransactionInvoiceInfo MultipleInvoicesInfo(TransactionInvoiceInfoBase transactionInvoiceInfoBase)
		{
			this.Request.Request.Endpoint += $"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}" +
											$"{Constants.Settings.GatewaySettings.InvoiceInfosEndPoint}";
            this.TransactionInvoiceInfoBase = transactionInvoiceInfoBase;

			return new ConfiguredTransactionInvoiceInfo(this);
		}

	}
}
