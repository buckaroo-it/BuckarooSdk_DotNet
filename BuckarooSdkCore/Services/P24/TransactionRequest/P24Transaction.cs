using System;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.P24.TransactionRequest
{
	/// <summary>
	/// In Poland 80% of all consumers use the payment method P24. It is an online banking payment method (transfer) 
	/// that enables consumers to do an online purchase via their online banking service. P24 covers over 35 banks in Poland.
	/// </summary>
	public class P24Transaction
	{
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal P24Transaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with an P24PayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A P24PayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(P24PayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);

			if(this.ConfiguredTransaction.BaseTransaction.TransactionBase.Currency != null 
					&& this.ConfiguredTransaction.BaseTransaction.TransactionBase.Currency.Equals("PLN", StringComparison.InvariantCulture))
			{
				this.ConfiguredTransaction.BaseTransaction.AuthenticatedRequest.Request.BuckarooSdkLogger
					.AddWarningLogging("P24 requests can only be performed with the currency Polish zloty (PLN)");
			}

			configuredServiceTransaction.BaseTransaction.AddService("Przelewy24", parameters, "pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The refund function creates a configured transaction with an P24RefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A P24RefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(P24RefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);

			if(this.ConfiguredTransaction.BaseTransaction.TransactionBase.Currency != null 
				&& this.ConfiguredTransaction.BaseTransaction.TransactionBase.Currency.Equals("PLN", StringComparison.InvariantCulture))
			{
				this.ConfiguredTransaction.BaseTransaction.AuthenticatedRequest.Request.BuckarooSdkLogger
					.AddWarningLogging("P24 requests can only be performed with the currency Polish zloty (PLN)");
			}

			configuredServiceTransaction.BaseTransaction.AddService("Przelewy24", parameters, "refund");

			return configuredServiceTransaction;
		}
	}
}