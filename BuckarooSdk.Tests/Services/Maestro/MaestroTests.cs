using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.CreditCards.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace BuckarooSdk.Tests.Services.Maestro
{
	[TestClass]
	public class MaestroTests
	{
		private SdkClient _sdkClient;
		private string TestName => nameof(MaestroTests).ToUpper();

		[TestInitialize]
		public void Setup()
		{
			this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
		}

		[TestMethod]
		public void PayTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{DateTime.Now.Ticks}",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Maestro()
				.Pay(new CreditCardPayRequest()
				{
					//set properties
					CustomerCode = "1234",
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void RefundTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountCredit = 0.02m,
					Invoice = $"SDK_{ TestName }_{DateTime.Now.Ticks}",
					OriginalTransactionKey = "59915ADC227149F4A3ACE9E0C8589D3C",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Maestro()
				.Refund(new CreditCardRefundRequest()
				{
					//set properties
				});
			var response = request.Execute();
		}

		[TestMethod]
		public void AuthorizeTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{DateTime.Now.Ticks}",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Maestro()
				.Authorize(new CreditCardAuthorizeRequest()
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void CaptureTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{DateTime.Now.Ticks}",
				})
				.Maestro()
				.Capture(new CreditCardCaptureRequest()
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRecurrent()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{DateTime.Now.Ticks}",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Maestro()
				.PayRecurrent(new CreditCardPayRecurrentRequest
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRemainder()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{DateTime.Now.Ticks}",
					Description = $"{ TestName }_SDK_UNITTEST",
				})
				.Maestro()
				.PayRemainder(new CreditCardPayRemainderRequest
				{
					//set properties
				});

			var response = request.Execute();
		}
	}
}
