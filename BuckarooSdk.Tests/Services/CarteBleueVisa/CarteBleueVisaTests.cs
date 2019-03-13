using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.CreditCards.Request;

namespace BuckarooSdk.Tests.Services.CarteBleueVisa
{
	[TestClass]
	public class CarteBleueVisaTests
	{
		private SdkClient _sdkClient;
		private string TestName => nameof(CarteBleueVisaTests).ToUpper();

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
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }"
				}
					.AddAdditionalParameter("add_test1", DateTime.Now.Ticks.ToString())
					.AddAdditionalParameter("add_test2", "test")
				)
				.CarteBleueVisa()
				.Pay(new CreditCardPayRequest()
				{
					//set properties
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
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }"
				})
				.CarteBleueVisa()
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
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }"
				}
					.AddAdditionalParameter("add_test1", DateTime.Now.Ticks.ToString())
					.AddAdditionalParameter("add_test2", "test")
				)
				.CarteBleueVisa()
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
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }"
				})
				.CarteBleueVisa()
				.Capture(new CreditCardCaptureRequest()
				{
					//set properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRecurrentTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }"
				})
				.CarteBleueVisa()
				.PayRecurrent(new CreditCardPayRecurrentRequest()
				{
					//define properties
				});

			var response = request.Execute();
		}

		[TestMethod]
		public void PayRemainderTest()
		{
			var request = this._sdkClient.CreateRequest()
				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.TransactionRequest()
				.SetBasicFields(new TransactionBase
				{
					Currency = "EUR",
					AmountDebit = 0.02m,
					Invoice = $"SDK_{ TestName }_{ DateTime.Now.Ticks }"
				})
				.CarteBleueVisa()
				.PayRemainder(new CreditCardPayRemainderRequest()
				{
					//define properties
				});

			var response = request.Execute();
		}
	}
}
