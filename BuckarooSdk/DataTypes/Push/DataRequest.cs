using System;
using System.Collections.Generic;
using System.Linq;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.DataTypes.Response.Status;
using BuckarooSdk.Services;
using Service = BuckarooSdk.DataTypes.Response.Service;

namespace BuckarooSdk.DataTypes.Push
{
	//TODO fill properties
	public class DataRequest : Push
	{
		/// <summary>
		/// The transaction key
		/// </summary>
		public string Key { get; set; }
		/// <summary>
		/// The status of the transaction
		/// </summary>
		public Status Status { get; set; }
		/// <summary>
		/// The list of services that were available for the transaction request
		/// </summary>
		public List<Service> Services { get; set; }
		/// <summary>
		/// The list of custom parameters that was sent with the transaction request
		/// </summary>
		public CustomParameters CustomParameters { get; set; }
		/// <summary>
		/// The list of additional parameters that was sent with the transaction request
		/// </summary>
		public AdditionalParameters AdditionalParameters { get; set; }
		/// <summary>
		/// The invoice used in the request.
		/// </summary>
		public string Invoice { get; set; }
		/// <summary>
		/// The code of the service used for the transaction.
		/// </summary>
		public string ServiceCode { get; set; }
		/// <summary>
		/// boolean that specifies if the transaction was a test transaction.
		/// </summary>
		public bool IsTest { get; set; }
		/// <summary>
		/// The currency that 
		/// </summary>
		public string Currency { get; set; }
		/// <summary>
		/// The debit amount of the requested transaction
		/// </summary>
		public decimal? AmountDebit { get; set; }
		/// <summary>
		/// The transaction type that was specified in the transaction request.
		/// </summary>
		public string TransactionType { get; set; }
		/// <summary>
		/// The mutation type of the transaction request. 
		/// </summary>
		public MutationType MutationType { get; set; }
		/// <summary>
		/// A list of transactions that are related to the transaction that was requested.
		/// </summary>
		public List<RelatedTransaction> RelatedTransactions { get; set; }
		/// <summary>
		/// The order value. This is an alphanumerical value.
		/// </summary>
		public string Order { get; set; }
		/// <summary>
		/// The issuing country of the requested transaction.
		/// </summary>
		public string IssuingCountry { get; set; }
		/// <summary>
		/// Boolean value that specifies wheter the requested transactions initiated a startrecurrent.
		/// </summary>
		public bool StartRecurrent { get; set; }
		/// <summary>
		/// Boolean value that specifies wheter the transaction is a recurring transaction.
		/// </summary>
		public bool Recurring { get; set; }
		/// <summary>
		/// The number of the customer that the transaction request was meant for.
		/// </summary>
		public string CustomerName { get; set; }
		/// <summary>
		/// The payer hash value of the requested transaction.
		/// </summary>
		public string PayerHash { get; set; }
		/// <summary>
		/// The key value of the payment.
		/// </summary>
		public string PaymentKey { get; set; }

		/// <summary>
		/// Primary constructor.
		/// </summary>
		public DataRequest()
		{
			this.Status = new Status();
		}

		public List<ServiceEnum> GetServices()
		{
			var services = new List<ServiceEnum>();
			foreach (var service in this.Services)
			{
				var serviceEnum = (ServiceEnum)Enum.Parse(typeof(ServiceEnum), service.Name, true);
				services.Add(serviceEnum);
			}

			return services;
		}

		// abstract class Response
		public T GetActionResponse<T>()
			where T : ActionResponse, new()
		{
			var result = new T();

			var service = this.Services.FirstOrDefault(s => s.Name.Equals(result.ServiceEnum.ToString(), StringComparison.OrdinalIgnoreCase));
			if (service == null) return null;

			result.FillFromResponse(service);

			return result;
		}
	}
}
