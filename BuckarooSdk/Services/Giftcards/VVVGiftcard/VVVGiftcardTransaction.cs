using BuckarooSdk.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Services.Giftcards.VVVGiftcard
{
	/// <summary>
	/// The Transaction class of payment method type: VVV giftcards.
	/// </summary>
	public class VVVGiftcardTransaction
	{
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal VVVGiftcardTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an VVV Giftcards PayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An VVV Giftcards PayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(VVVGiftcardPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("vvvgiftcard", parameters, "pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The refund function creates a configured transaction with an VVV Giftcards RefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An VVV Giftcards RefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(VVVGiftcardRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("vvvgiftcard", parameters, "refund");

			return configuredServiceTransaction;
		}
	}
}
