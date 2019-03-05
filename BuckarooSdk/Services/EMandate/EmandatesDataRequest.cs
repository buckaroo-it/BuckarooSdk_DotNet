using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.EMandate
{
	public class EmandatesDataRequest
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredDataRequest ConfiguredDataRequest { get; set; }

		internal EmandatesDataRequest(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		/// <summary>
		/// The CreateMandate function creates a configured transaction with an EMandateCreateMandateRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A EMandateCreateMandateRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CreateMandate(EMandateCreateMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("emandate", parameters, "CreateMandate", "1");

			return configuredServiceTransaction;
		}

		///// <summary>
		///// The GetIssuerList function creates a configured transaction with an EMandateGetIssuerListRequest request, 
		///// that is ready to be executed.
		///// </summary>
		///// <param name="request">A EMandateGetIssuerListRequest</param>
		///// <returns></returns>
		//public ConfiguredServiceTransaction GetIssuerList(EMandateGetIssuerListRequest request)
		//{
		//	var parameters = ServiceHelper.CreateServiceParameters(request);
		//	var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
		//	configuredServiceTransaction.BaseTransaction.AddService("emandate", parameters, "GetIssuerList", "1");

		//	return configuredServiceTransaction;
		//}

		///// <summary>
		///// The GetStatus function creates a configured transaction with an EMandateGetStatusRequest request, 
		///// that is ready to be executed.
		///// </summary>
		///// <param name="request">A EMandateGetStatusRequest</param>
		///// <returns></returns>
		//public ConfiguredServiceTransaction GetStatus(EMandateGetStatusRequest request)
		//{
		//	var parameters = ServiceHelper.CreateServiceParameters(request);
		//	var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
		//	configuredServiceTransaction.BaseTransaction.AddService("emandate", parameters, "GetStatus", "1");

		//	return configuredServiceTransaction;
		//}

		///// <summary>
		///// The ModifyMandate function creates a configured transaction with an EMandateModifyMandateRequest request, 
		///// that is ready to be executed.
		///// </summary>
		///// <param name="request">A EMandateModifyMandateRequest</param>
		///// <returns></returns>
		//public ConfiguredServiceTransaction ModifyMandate(EMandateModifyMandateRequest request)
		//{
		//	var parameters = ServiceHelper.CreateServiceParameters(request);
		//	var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
		//	configuredServiceTransaction.BaseTransaction.AddService("emandate", parameters, "ModifyMandate", "1");

		//	return configuredServiceTransaction;
		//}
	}
}
