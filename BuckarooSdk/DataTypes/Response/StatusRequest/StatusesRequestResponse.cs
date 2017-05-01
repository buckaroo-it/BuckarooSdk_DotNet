using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.DataTypes.Response.StatusRequest;

namespace BuckarooSdk.DataTypes.Response.StatusRequest
{
	public class StatusesRequestResponse : IRequestResponse
	{
		public List<TransactionStatus> Transactions { get;set; }
		public List<InvalidTransaction> ErrorTransactions { get; set; }
	}
}
