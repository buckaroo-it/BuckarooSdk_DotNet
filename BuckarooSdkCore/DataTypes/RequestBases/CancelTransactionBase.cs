using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.RequestBases
{
	public class CancelTransactionBase : IRequestBase
	{
		public List<CancelTransaction> Transactions { get; set; }

		public CancelTransactionBase(IEnumerable<string> transactions)
		{
			this.Transactions = new List<CancelTransaction>();
			foreach (var transaction in transactions)
			{
				this.Transactions.Add(new CancelTransaction(transaction));
			}
		}

		public CancelTransactionBase(string transactionToBeCanceled)
		{
			this.Transactions = new List<CancelTransaction>();
			this.Transactions.Add(new CancelTransaction(transactionToBeCanceled));
		}
	}

	public class CancelTransaction
	{
		public string Key { get; set; }

		public CancelTransaction(string key)
		{
			this.Key = key;
		}

		public CancelTransaction()
		{
			
		}
	}
}
