using BuckarooSdk.Data;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.KlarnaKP
{
    public class KlarnaRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }
		private ConfiguredDataRequest ConfiguredDataRequest { get; }

		internal KlarnaRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		internal KlarnaRequestObject(ConfiguredDataRequest configuredDataRequest)
		{
			this.ConfiguredDataRequest = configuredDataRequest;
		}

		/// <summary>
		/// The Reserve function creates a configured dataRequest with an KlarnaReserveRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KlarnaReserveRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest Reserve(KlarnaReserveRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("klarnakp", parameters, "Reserve");

			return configuredServiceDataRequest;
		}

		/// <summary>
		/// The CancelReservation function creates a configured dataRequest with an KlarnaCancelReservationRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KlarnaCancelReservationRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest CancelReservation(KlarnaCancelReservationRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("klarnakp", parameters, "CancelReservation");

			return configuredServiceDataRequest;
		}


		/// <summary>
		/// The Pay function creates a configured transaction with an KlarnaPayRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KlarnaPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(KlarnaPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("klarnakp", parameters, "Pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The Refund function creates a configured transaction with an KlarnaRefundRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KlarnaRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(KlarnaRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("klarnakp", parameters, "Refund");

			return configuredServiceTransaction;
		}
		
		/// <summary>
		/// The UpdateReservation function creates a configured dataRequest with an KlarnaUpdateReservationRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A KlarnaUpdateReservationRequest</param>
		/// <returns></returns>
		public ConfiguredServiceDataRequest UpdateReservation(KlarnaUpdateReservationRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
            configuredServiceDataRequest.BaseData.AddService("klarnakp", parameters, "UpdateReservation");

			return configuredServiceDataRequest;
		}

        /// <summary>
        /// The GetPClasses function creates a configured dataRequest with an KlarnaGetPClassesRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A KlarnaGetPClassesRequest</param>
        /// <returns></returns>
        //public ConfiguredServiceDataRequest GetPClasses(KlarnaGetPClassesRequest request)
        //{
        //	var parameters = ServiceHelper.CreateServiceParameters(request);
        //	var configuredServiceDataRequest = new ConfiguredServiceDataRequest(this.ConfiguredDataRequest.BaseDataRequest);
        //	configuredServiceDataRequest.BaseData.AddService("klarna", parameters, "GetPClasses");

        //	return configuredServiceDataRequest;
        //}
    }
}
