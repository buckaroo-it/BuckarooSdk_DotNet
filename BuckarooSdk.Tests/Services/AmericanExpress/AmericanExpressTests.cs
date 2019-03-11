using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.CreditCards.AmericanExpress.Constants;
using BuckarooSdk.Services.CreditCards.AmericanExpress.TransactionRequest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.AmericanExpress
{
	[TestClass]
	public class AmericanExpressTests
	{
		private SdkClient _sdkClient;

		[TestInitialize]
		public void Setup()
		{
			this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
		}

		[TestMethod]
		public void PayTest()
		{
			var request = this._sdkClient.CreateRequest()

				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, Constants.TestSettings.Test,
					new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "AMEX_PAY_SDK_TEST",
					ReturnUrl = Constants.TestSettings.ReturnUrl,
					ReturnUrlCancel = Constants.TestSettings.ReturnUrlCancel,
					ReturnUrlError = Constants.TestSettings.ReturnUrlError,
					ReturnUrlReject = Constants.TestSettings.ReturnUrlReject,
				})
				.AmericanExpress()
				.Pay(new AmericanExpressPayRequest()
				{
					CustomerEmail = "techsup@buckaroo.nl",
					BillingFirstName = "Jacobus",
					ShippingLastName = "Roos",
					ShippingMethodCode = ShippingMethod.SameDay,
					Recurring = Recurring.None,
				});

			var response = request.Execute();

			if (response.Status.Code.Code == BuckarooSdk.Constants.Status.PendingInput)
			{
				Process.Start(response.RequiredAction.RedirectURL);
			}
		}

		[TestMethod]
		public void RefundTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, Constants.TestSettings.Test,
					new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountCredit = 0.02m,
					Invoice = "SDK_TEST_636167137486595015",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = Constants.TestSettings.ReturnUrl,
					ReturnUrlCancel = Constants.TestSettings.ReturnUrlCancel,
					ReturnUrlError = Constants.TestSettings.ReturnUrlError,
					ReturnUrlReject = Constants.TestSettings.ReturnUrlReject,
					OriginalTransactionKey = "D71088D71A4D49EFA4B1603C50220D89"
				})
				.AmericanExpress()
				.Refund(new AmericanExpressRefundRequest()
				{
					// no parameters are required.
				});
			var response = request.Execute();
		}
		
		[TestMethod]
		public void AuthorizeTest()
		{
			this._sdkClient = new SdkClient();
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, Constants.TestSettings.Test,
					new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = Constants.TestSettings.ReturnUrl,
					ReturnUrlCancel = Constants.TestSettings.ReturnUrlCancel,
					ReturnUrlError = Constants.TestSettings.ReturnUrlError,
					ReturnUrlReject = Constants.TestSettings.ReturnUrlReject,
				})
				.AmericanExpress()
				.Authorize(new AmericanExpressAuthorizeRequest()
				{
					CustomerEmail = "techsup@buckaroo.nl",
					BillingFirstName = "Jacobus",
					ShippingLastName = "Roos",
					ShippingMethodCode = ShippingMethod.SameDay,
				});

			var response = request.Execute();

			if (response.Status.Code.Code == BuckarooSdk.Constants.Status.PendingInput)
			{
				Process.Start(response.RequiredAction.RedirectURL);
			}
		}

		[TestMethod]
		public void PayRecurrentTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, Constants.TestSettings.Test,
					new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = Constants.TestSettings.ReturnUrl,
					ReturnUrlCancel = Constants.TestSettings.ReturnUrlCancel,
					ReturnUrlError = Constants.TestSettings.ReturnUrlError,
					ReturnUrlReject = Constants.TestSettings.ReturnUrlReject,
				})
				.AmericanExpress()
				.PayRecurrent(new AmericanExpressPayRecurrentRequest()
				{

				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRemainderTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, Constants.TestSettings.Test,
					new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
					Description = "IDEAL_PAY_SDK_UNITTEST",
					ReturnUrl = Constants.TestSettings.ReturnUrl,
					ReturnUrlCancel = Constants.TestSettings.ReturnUrlCancel,
					ReturnUrlError = Constants.TestSettings.ReturnUrlError,
					ReturnUrlReject = Constants.TestSettings.ReturnUrlReject,
				})
				.AmericanExpress()
				.PayRemainder(new AmericanExpressPayRemainderRequest()
				{

				});
			var response = request.Execute();
		}
	}
}
