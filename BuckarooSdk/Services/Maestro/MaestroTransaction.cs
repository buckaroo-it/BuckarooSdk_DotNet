using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Maestro
{
	public class MaestroTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get;}

		internal MaestroTransaction(ConfiguredTransaction baseTransaction)
		{
			this.ConfiguredTransaction = baseTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a MaestroPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A MaestroPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(MaestroPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Mastercard", parameters, "pay");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction Authorize(MaestroAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Mastercard", parameters, "authorize");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction PayRecurrent(MaestroPayRecurrentRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Mastercard", parameters, "payrecurrent");

			return configuredServiceTransaction;
		}
		public ConfiguredServiceTransaction PayRemainder(MaestroPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Mastercard", parameters, "payremainder");

			return configuredServiceTransaction;
		}
	}
}
