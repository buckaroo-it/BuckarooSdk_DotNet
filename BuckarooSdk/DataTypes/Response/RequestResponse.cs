using BuckarooSdk.DataTypes.Response.Error;
using BuckarooSdk.Logging;
using BuckarooSdk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// The response message after a transaction is sent. It can be used to verify whether a transaction 
	/// has been send, received, and processed properly. If something went wrong, it can also be read from
	/// the response.
	/// </summary>
	public class RequestResponse : IRequestResponse
	{
		/// <summary>
		/// The BuckarooLogger is set on the response object in order to make it easy for the user to retrieve the logging.
		/// The users system does not need to worry about setting the Logger, because it is set by the request, after it
		/// is performed.
		/// </summary>
		public ILogger BuckarooSdkLogger { get; internal set; }
		/// <summary>
		/// The transaction key
		/// </summary>
		public string Key { get; set; }
		/// <summary>
		/// The status of the transaction
		/// </summary>
		public Status.Status Status { get; set; }
		/// <summary>
		/// The required action
		/// </summary>
		public RequiredAction RequiredAction { get; set; }
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
		/// An overcoupling error overview with list of all errors per error type.
		/// </summary>
		public RequestErrors RequestErrors { get; set; }
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
		/// The consumer message
		/// </summary>
		public ConsumerMessage ConsumerMessage { get; set; }
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

		public string RawRequest => this.BuckarooSdkLogger.GetRawRequest();

		public string RawResponse => this.BuckarooSdkLogger.GetRawResponse();

		/// <summary>
		/// Primary constructor.
		/// </summary>
		public RequestResponse()
		{
			this.Status = new Status.Status();
		}

		public List<ServiceNames> GetServices()
		{
			var services = new List<ServiceNames>();
			foreach (var service in this.Services)
			{
				var serviceEnum = (ServiceNames)Enum.Parse(typeof(ServiceNames), service.Name, true);
				services.Add(serviceEnum);
			}

			return services;
		}

		public bool CheckResponseForErrors()
		{
			
			foreach (var actionError in RequestErrors.ActionErrors)
			{
				
			}

			return false;
		}

		/// <summary>
		/// Returns the typed reponse for a specific action from the request. In case multiple services were used within one request, 
		/// this method provides the response voor a certain action (e.g. response.GetActionResponse<IdealPayResponse/>();)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetActionResponse<T>()
			where T : ActionResponse, new()
		{
			var result = new T();

			var service = this.Services.FirstOrDefault(s => s.Name.Equals(result.ServiceNames.ToString(), StringComparison.OrdinalIgnoreCase));
			if (service == null) return null;

			result.FillFromResponse(service);

			return result;
		}
	}
}
