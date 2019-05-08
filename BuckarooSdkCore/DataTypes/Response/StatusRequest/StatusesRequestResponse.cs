using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response.StatusRequest
{
	public class StatusesRequestResponse : IRequestResponse
	{
		public List<TransactionStatus> Transactions { get;set; }
		public List<InvalidTransaction> ErrorTransactions { get; set; }
	}
}
