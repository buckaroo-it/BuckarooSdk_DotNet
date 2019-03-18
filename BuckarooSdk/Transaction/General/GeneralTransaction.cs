using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Transaction.General
{
	/// <summary>
	/// Transaction type that can be used when the choice of payment method needs to be done within the Buckaroo Checkout
	/// 
	/// </summary>
	public class GeneralTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal GeneralTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

	}
}
