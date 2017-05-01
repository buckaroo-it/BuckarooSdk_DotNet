using BuckarooSdk.Data;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	public class CreditManagementDataRequest
	{
		private ConfiguredDataRequest ConfiguredDataRequest { get; set; }

		internal CreditManagementDataRequest(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		#region actions

		/// <summary>
		/// The CreateInvoice function creates a configured transaction with an 
		/// CreditManagementCreateInvoiceRequest, that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditManagementCreateInvoiceRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CreateInvoice(CreditManagementCreateInvoiceRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("CreditManagement3", parameters, "CreateInvoice");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The CreateCombinedInvoice function creates a configured data request with an 
		/// CreditManagementInvoiceRequest, that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditManagementCreateCreditNoteRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CreateCreditNote(CreditManagementCreateCreditNoteRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataRequest.BaseData.AddService("CreditManagement3", parameters, "CreateCombinedInvoice");

			return configuredServiceDataRequest;
		}

		/// <summary>
		/// The AddOrUpdateDebtor function creates a configured data requestwith an CreditManagementAddOrUpdateDebtorRequest,
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest AddOrUpdateDebtor(CreditManagementAddOrUpdateDebtorRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataRequest.BaseData.AddService("CreditManagement3", parameters, "AddOrUpdateDebtor");

			return configuredServiceDataRequest;
		}
		
		/// <summary>
		/// The CreatePaymentPlan function creates a configured data request with an CreditManagementCreatePaymentPlanRequest,
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CreatePaymentPlan (CreditManagementCreatePaymentPlanRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataRequest.BaseData.AddService("CreditManagement3", parameters, "CreatePaymentPlan");

			return configuredServiceDataRequest;
		}

		/// <summary>
		/// The TerminatePaymentPlan function creates a configured data requestwith an CreditManagementCreatePaymentPlanRequest,
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest TerminatePaymentPlan(CreditManagementCreatePaymentPlanRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceDataRequest.BaseData.AddService("CreditManagement3", parameters, "TerminatePaymentPlan");

			return configuredServiceDataRequest;
		}

		#endregion
	}
}
