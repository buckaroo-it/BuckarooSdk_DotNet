using BuckarooSdk.Services.CreditCards.BanContact.Request;
using BuckarooSdk.Transaction;

namespace BuckarooSdk.Services.CreditCards.BanContact
{
    public class BancontactTransaction
    {
        /// <summary>
		/// The configured transaction
		/// </summary>
        private ConfiguredTransaction ConfiguredTransaction { get; set; }

        internal BancontactTransaction(ConfiguredTransaction configuredTransaction)
        {
            this.ConfiguredTransaction = configuredTransaction;
        }

		/// <summary>
        /// The Pay function creates a configured transaction with an BancontactPayRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BancontactPayRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Pay(BancontactPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("bancontactmrcash", parameters, "Pay", "1");

			return configuredServiceTransaction;
		}

/// <summary>
        /// The Refund function creates a configured transaction with an BancontactRefundRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BancontactRefundRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction Refund(BancontactRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("bancontactmrcash", parameters, "Refund", "1");

			return configuredServiceTransaction;
		}

/// <summary>
        /// The PayRemainder function creates a configured transaction with an BancontactPayRemainderRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BancontactPayRemainderRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayRemainder(BancontactPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("bancontactmrcash", parameters, "PayRemainder", "1");

			return configuredServiceTransaction;
		}

/// <summary>
        /// The PayEncrypted function creates a configured transaction with an BancontactPayEncryptedRequest request, 
        /// that is ready to be executed.
        /// </summary>
        /// <param name="request">A BancontactPayEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayEncrypted(BancontactPayEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request);
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("bancontactmrcash", parameters, "PayEncrypted", "1");

			return configuredServiceTransaction;
		}


	}
}
