using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.OnlineGiroLite
{
	public class OnlineGiroLiteRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal OnlineGiroLiteRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The PaymentInvitation function creates a configured transaction with an OnlineGiroLitePaymentInvitationRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A OnlineGiroLitePaymentInvitationRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PaymentInvitation(OnlineGiroLitePaymentInvitationRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("onlinegirolite", parameters, "PaymentInvitation");

			return configuredServiceTransaction;
		}
	}
}
