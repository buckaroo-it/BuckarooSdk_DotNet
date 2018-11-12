using BuckarooSdk.Data;

namespace BuckarooSdk.Services.Emandates.DataRequest
{
	public class EmandatesDataRequest
	{
		private ConfiguredDataRequest ConfiguredDataRequest { get; set; }

		internal EmandatesDataRequest(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		#region actions

		public ConfiguredServiceDataRequest CreateMandate(EmandatesCreateMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("emandates", parameters, "CreateMandate");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceDataRequest ModifyMandate(EmandatesModifyMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("emandates", parameters, "ModifyMandate");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceDataRequest CancelMandate(EmandatesCancelMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("emandates", parameters, "CancelMandate");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceDataRequest GetStatus(EmandatesCancelMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("emandates", parameters, "GetStatus");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceDataRequest GetIssuerList(EmandatesCancelMandateRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
			configuredServiceTransaction.BaseData.AddService("emandates", parameters, "GetIssuerList");

			return configuredServiceTransaction;
		}

		#endregion
	}
}