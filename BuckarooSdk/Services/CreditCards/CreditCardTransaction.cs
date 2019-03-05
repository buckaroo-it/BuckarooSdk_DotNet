using BuckarooSdk.Services.CreditCards.MasterCard.Request;
using BuckarooSdk.Services.CreditCards.Request;
using BuckarooSdk.Services.CreditCards.Visa.Request;
using BuckarooSdk.Transaction;
using System;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.CreditCards
{
	public class CreditCardTransaction
	{
		/// <summary>
		/// The configured transaction
		/// </summary>
		private ConfiguredTransaction ConfiguredTransaction { get; }
		internal ServiceNames ServiceName { get; set; }

		internal CreditCardTransaction(ConfiguredTransaction baseTransaction, ServiceNames serviceName)
		{
			this.ConfiguredTransaction = baseTransaction;
			this.ServiceName = serviceName;
		}

		#region MasterCard
		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardPayRequest</param>
		/// <returns></returns>
		[Obsolete]
		public ConfiguredServiceTransaction Pay(MasterCardPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "pay");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardRefundRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardRefundRequest</param>
		[Obsolete]
		public ConfiguredServiceTransaction Refund(MasterCardRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "refund");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardAuthorizeRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardAuthorizeRequest</param>
		[Obsolete]
		public ConfiguredServiceTransaction Authorize(MasterCardAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "authorize");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardCaptureRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardCaptureRequest</param>
		[Obsolete]
		public ConfiguredServiceTransaction Capture(MasterCardCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "capture");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardPayRecurrentRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardPayRecurrentRequest</param>
		[Obsolete]
		public ConfiguredServiceTransaction PayRecurrent(MasterCardPayRecurrentRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "payrecurrent");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardPayRemainderRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardPayRemainderRequest</param>
		[Obsolete]
		public ConfiguredServiceTransaction PayRemainder(MasterCardPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "payremainder");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The CancelAuthorize function creates a configured transaction with an VisaCancelAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A VisaCancelAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CancelAuthorize(MasterCardCancelAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("mastercard", parameters, "CancelAuthorize", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayEncrypted function creates a configured transaction with an MasterCardPayEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A MasterCardPayEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayEncrypted(MasterCardPayEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("mastercard", parameters, "PayEncrypted", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The AuthorizeEncrypted function creates a configured transaction with an MasterCardAuthorizeEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A MasterCardAuthorizeEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction AuthorizeEncrypted(MasterCardAuthorizeEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("MasterCard", parameters, "AuthorizeEncrypted", "1");

			return configuredServiceTransaction;
		}
		#endregion

		#region Visa
		/// <summary>
		/// The pay function creates a configured transaction with a CreditCardPayRequest, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardPayRequest</param>
		/// <returns></returns>
		[Obsolete]
		public ConfiguredServiceTransaction Pay(VisaPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Visa", parameters, "pay");

			return configuredServiceTransaction;
		}

		[Obsolete]
		public ConfiguredServiceTransaction Refund(VisaRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Visa", parameters, "refund");

			return configuredServiceTransaction;
		}

		[Obsolete]
		public ConfiguredServiceTransaction Authorize(VisaAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Visa", parameters, "authorize");

			return configuredServiceTransaction;
		}

		[Obsolete]
		public ConfiguredServiceTransaction Capture(VisaCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Visa", parameters, "capture");

			return configuredServiceTransaction;
		}

		[Obsolete]
		public ConfiguredServiceTransaction PayRecurrent(VisaPayRecurrentRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Visa", parameters, "payrecurrent");

			return configuredServiceTransaction;
		}

		[Obsolete]
		public ConfiguredServiceTransaction PayRemainder(VisaPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("Visa", parameters, "payremainder");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The CancelAuthorize function creates a configured transaction with an VisaCancelAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A VisaCancelAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CancelAuthorize(VisaCancelAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("visa", parameters, "CancelAuthorize", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayEncrypted function creates a configured transaction with an VisaPayEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A VisaPayEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayEncrypted(VisaPayEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("visa", parameters, "PayEncrypted", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The AuthorizeEncrypted function creates a configured transaction with an VisaAuthorizeEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A VisaAuthorizeEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction AuthorizeEncrypted(VisaAuthorizeEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService("visa", parameters, "AuthorizeEncrypted", "1");

			return configuredServiceTransaction;
		}
		#endregion

		#region CreditCard
		public ConfiguredServiceTransaction Pay(CreditCardPayRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "pay");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceTransaction Refund(CreditCardRefundRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "refund");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceTransaction Authorize(CreditCardAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "authorize");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceTransaction Capture(CreditCardCaptureRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "capture");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceTransaction PayRecurrent(CreditCardPayRecurrentRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "payrecurrent");

			return configuredServiceTransaction;
		}

		public ConfiguredServiceTransaction PayRemainder(CreditCardPayRemainderRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "payremainder");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The CancelAuthorize function creates a configured transaction with an CreditCardCancelAuthorizeRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardCancelAuthorizeRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction CancelAuthorize(CreditCardCancelAuthorizeRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "CancelAuthorize", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The PayEncrypted function creates a configured transaction with an CreditCardPayEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardPayEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction PayEncrypted(CreditCardPayEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "PayEncrypted", "1");

			return configuredServiceTransaction;
		}

		/// <summary>
		/// The AuthorizeEncrypted function creates a configured transaction with an CreditCardAuthorizeEncryptedRequest request, 
		/// that is ready to be executed.
		/// </summary>
		/// <param name="request">A CreditCardAuthorizeEncryptedRequest</param>
		/// <returns></returns>
		public ConfiguredServiceTransaction AuthorizeEncrypted(CreditCardAuthorizeEncryptedRequest request)
		{
			var parameters = ServiceHelper.CreateServiceParameters(request, this.ServiceName.ToString());
			var configuredServiceTransaction = new ConfiguredServiceTransaction(this.ConfiguredTransaction.BaseTransaction);
			configuredServiceTransaction.BaseTransaction.AddService(this.ServiceName.ToString(), parameters, "AuthorizeEncrypted", "1");

			return configuredServiceTransaction;
		}
		#endregion
	}
}
