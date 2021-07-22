using System;
using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Transaction.RefundInfo
{
    public class TransactionRefundInfo
    {
        internal AuthenticatedRequest AuthenticatedRequest { get; set; }

        internal TransactionRefundInfoBase TransactionRefundInfoBase { get; set; }

        public TransactionRefundInfo(AuthenticatedRequest request)
        {
            AuthenticatedRequest = request;
        }

        public ConfiguredTransactionRefundInfo SpecificConfiguredTransactionRefundInfo(string transactionKey)
        {
            AuthenticatedRequest.Request.Endpoint += $"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}{Constants.Settings.GatewaySettings.RefundInfoEndPoint}{transactionKey}";

            return new ConfiguredTransactionRefundInfo(this);
        }
        
        public ConfiguredTransactionRefundInfo MultipleConfiguredTransactionRefundInfo()
        {
            AuthenticatedRequest.Request.Endpoint += $"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}{Constants.Settings.GatewaySettings.RefundInfosEndPoint}";

            return new ConfiguredTransactionRefundInfo(this);
        }

        [Obsolete("Parameter transactionRefundInfoBase is no longer needed.")]
        public ConfiguredTransactionRefundInfo MultipleConfiguredTransactionRefundInfo(TransactionRefundInfoBase transactionRefundInfoBase)
        {
            return MultipleConfiguredTransactionRefundInfo();
        }
    }
}
