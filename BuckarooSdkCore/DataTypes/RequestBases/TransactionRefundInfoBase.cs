
using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.RequestBases
{
	public class TransactionRefundInfoBase : IRequestBase
	{
		public List<RefundInfoRequestRefundInfo> RefundInfoCollection { get; set; }

		public TransactionRefundInfoBase()
		{

		}
		public TransactionRefundInfoBase(List<string> transactionKeys)
		{
			this.RefundInfoCollection = new List<RefundInfoRequestRefundInfo>();
			foreach(var key in transactionKeys)
			{
				this.RefundInfoCollection.Add(new RefundInfoRequestRefundInfo()
				{
					TransactionKey = key,
				});
			}
		}

		public void AddRefund(string transactionKey)
		{
			this.RefundInfoCollection.Add(new RefundInfoRequestRefundInfo()
			{
				TransactionKey = transactionKey,
			});
		}
	}
}
