using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.OnlineGiro
{
    public class OnlineGiroRequestObject
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; }

        internal OnlineGiroRequestObject(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

		/// <summary>
        /// The PaymentInvitation function creates a configured transaction with an OnlineGiroPaymentInvitationRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A OnlineGiroPaymentInvitationRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PaymentInvitation(OnlineGiroPaymentInvitationRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("onlinegiro", parameters, "PaymentInvitation");

			return configuredServiceTransaction;
		}


	}
}
