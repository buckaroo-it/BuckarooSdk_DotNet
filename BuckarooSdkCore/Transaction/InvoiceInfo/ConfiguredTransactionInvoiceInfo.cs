using System;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.DataTypes.Response.InvoiceInfo;

namespace BuckarooSdk.Transaction.InvoiceInfo
{
	public class ConfiguredTransactionInvoiceInfo
	{
		internal TransactionInvoiceInfo TransactionInvoiceInfo { get; set; }

		internal ConfiguredTransactionInvoiceInfo(TransactionInvoiceInfo transactionInvoiceInfo)
		{
			this.TransactionInvoiceInfo = transactionInvoiceInfo;
		}

		public InvoiceInfoRequestInvoice GetSingleInvoiceInfoRequest()
		{
			return Connection.Connector.SendRequest<IRequestBase, InvoiceInfoRequestInvoice>
				(this.TransactionInvoiceInfo.Request.Request, this.TransactionInvoiceInfo.TransactionInvoiceInfoBase, HttpRequestType.Get).Result;
		}

		public InvoiceInfoResponse GetMultipleInvoiceInfoRequest()
		{
			if (this.TransactionInvoiceInfo.Request.Request == null)
			{
				throw new Exception("This function is a POST method and should therefore contain a message body");
			}
			return Connection.Connector.SendRequest<IRequestBase, InvoiceInfoResponse>
				(this.TransactionInvoiceInfo.Request.Request, this.TransactionInvoiceInfo.TransactionInvoiceInfoBase, HttpRequestType.Post).Result;
		}
	}
}
