using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.Notification
{
	public class NotificationRequestObject
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }

		internal NotificationRequestObject(ConfiguredTransaction configuredTransaction)
		{
			this.ConfiguredTransaction = configuredTransaction;
		}

		/// <summary>
		/// The ExtraInfo function creates a configured transaction with an NotificationExtraInfoRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A NotificationExtraInfoRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction ExtraInfo(NotificationExtraInfoRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("notification", parameters, "ExtraInfo");

			return configuredServiceTransaction;
		}
	}
}
