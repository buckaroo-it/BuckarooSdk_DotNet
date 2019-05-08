using System;
using System.Collections.Generic;
using System.Linq;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.DataTypes.Response.StatusRequest;

namespace BuckarooSdk.Transaction.Status
{
	public class ConfiguredTransactionStatus
	{
		internal TransactionStatus TransactionStatus { get; set; }
		internal TransactionReference TransactionReference { get; set; }

		internal ConfiguredTransactionStatus(TransactionStatus transactionStatus)
		{
			this.TransactionStatus = transactionStatus;
			const string qwe = "";

			var list = new List<string>();
			var list2 = list.ToList();
		}
		

		public StatusesRequestResponse GetMultipleStatuses()
		{
			if (this.TransactionStatus.Request.Request == null)
			{
				throw new Exception("This function is a POST method and should therefore contain a message body");
			}
			return Connection.Connector.SendRequest<IRequestBase, StatusesRequestResponse>
				(this.TransactionStatus.Request.Request, this.TransactionStatus.TransactionStatusBase, HttpRequestType.Post).Result;
		}

		public DataTypes.Response.StatusRequest.TransactionStatus GetSingleStatus()
		{

			return Connection.Connector.SendRequest<IRequestBase, DataTypes.Response.StatusRequest.TransactionStatus>
				(this.TransactionStatus.Request.Request, this.TransactionStatus.TransactionStatusBase, HttpRequestType.Get).Result;
		}
	}
}
