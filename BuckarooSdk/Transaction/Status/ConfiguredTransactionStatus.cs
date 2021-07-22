using System;
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
            TransactionStatus = transactionStatus;
        }

        public StatusesRequestResponse GetMultipleStatuses()
        {
            if (TransactionStatus.Request.Request == null)
            {
                throw new Exception("This function is a POST method and should therefore contain a message body");
            }

            return Connection.Connector.SendRequest<IRequestBase, StatusesRequestResponse>(TransactionStatus.Request.Request, TransactionStatus.TransactionStatusBase, HttpRequestType.Post).Result;
        }

        public DataTypes.Response.StatusRequest.TransactionStatus GetSingleStatus()
        {
            return Connection.Connector.SendRequest<IRequestBase, DataTypes.Response.StatusRequest.TransactionStatus>(TransactionStatus.Request.Request, TransactionStatus.TransactionStatusBase, HttpRequestType.Get).Result;
        }
    }
}
