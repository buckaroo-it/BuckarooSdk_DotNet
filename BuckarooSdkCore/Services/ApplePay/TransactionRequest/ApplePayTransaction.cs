using BuckarooSdk.Services;
using BuckarooSdk.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuckarooSdkCore.Services.ApplePay.TransactionRequest
{
	public class ApplePayTransaction
	{

		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }


		internal ApplePayTransaction(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}


		/// <summary>
		/// The pay function creates a configured transaction with an IdealPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">An IdealPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(ApplePayPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("applepay", parameters, "pay", "2");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceTransaction Refund(ApplePayRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("applepay", parameters, "refund", "2");

			return configuredServiceTransaction;
		}
	}
}
