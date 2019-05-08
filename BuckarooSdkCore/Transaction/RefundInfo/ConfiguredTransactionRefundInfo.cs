using System;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Transaction.RefundInfo
{
	public class ConfiguredTransactionRefundInfo
	{
		internal TransactionRefundInfo TransactionRefundInfo { get; set; }

		internal ConfiguredTransactionRefundInfo(TransactionRefundInfo transactionRefundInfo)
		{
			this.TransactionRefundInfo = transactionRefundInfo;
		}

		public RefundInfoRequestRefundInfo GetSingleRefundInfo()
		{
			return Connection.Connector.SendRequest<IRequestBase, RefundInfoRequestRefundInfo>
				(this.TransactionRefundInfo.AuthenticatedRequest.Request, this.TransactionRefundInfo.TransactionRefundInfoBase, HttpRequestType.Get).Result;
		}

		public DataTypes.Response.RefundInfo.RefundInfo GetMultipleRefundsInfo()
		{
			if (this.TransactionRefundInfo.AuthenticatedRequest.Request == null)
			{
				throw new Exception("This function is a POST method and should therefore contain a message body");
			}
			return Connection.Connector.SendRequest<IRequestBase, DataTypes.Response.RefundInfo.RefundInfo>
				(this.TransactionRefundInfo.AuthenticatedRequest.Request, this.TransactionRefundInfo.TransactionRefundInfoBase, HttpRequestType.Post).Result;	
		}
	}
}
