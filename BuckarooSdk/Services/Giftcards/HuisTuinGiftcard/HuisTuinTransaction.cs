using BuckarooSdk.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Services.Giftcards.HuisTuinGiftcard
{
	/// <summary>
	/// The Transaction class of payment method type: Huis en Tuin giftcards.
	/// </summary>
	public class HuisTuinTransaction
	{
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal HuisTuinTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an IdealPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(HuisTuinGiftcardPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("huistuincadeau", parameters, "pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The refund function creates a configured transaction with an IdealRefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(HuisTuinGiftcardRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("huistuincadeau", parameters, "refund");

			return configuredServiceTransaction;
		}
	}
}
