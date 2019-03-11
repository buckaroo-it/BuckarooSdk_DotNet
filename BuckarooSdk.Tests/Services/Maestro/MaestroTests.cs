//using System;
//using System.Globalization;
//using BuckarooSdk.DataTypes.RequestBases;
//using BuckarooSdk.ServiceList.Maestro;
//using BuckarooSdk.ServiceList.MasterCard;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace BuckarooSdk.Tests.ServiceList.Maestro
//{
//	[TestClass]
//	public class MaestroTests
//	{
//		private SdkClient _sdkClient;

//		[TestInitialize]
//		public void Setup()
//		{
//			this._sdkClient = new SdkClient(Constants.TestSettings.Logger);
//		}

//		[TestMethod]
//		public void PayTest()
//		{
//			var request = this._sdkClient.CreateRequest()
//				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
//				.TransactionRequest()
//				.SetBasicFields(new TransactionBase
//				{
//					Currency = "EUR",
//					AmountDebit = 0.02m,
//					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
//					Description = "MAESTRO_PAY_SDK_UNITTEST",
//				})
//				.Maestro()
//				.Pay(new MaestroPayRequest
//				{
//					//set properties
//				});

//			var response = request.Execute();
//		}

//		[TestMethod]
//		public void AuthorizeTest()
//		{
//			var request = this._sdkClient.CreateRequest()
//				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
//				.TransactionRequest()
//				.SetBasicFields(new TransactionBase
//				{
//					Currency = "EUR",
//					AmountDebit = 0.02m,
//					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
//					Description = "MAESTRO_AUTHORIZE_SDK_UNITTEST",
//				})
//				.Maestro()
//				.Authorize(new MaestroAuthorizeRequest()
//				{
//					//set properties
//				});

//			var response = request.Execute();
//		}

//		[TestMethod]
//		public void PayRecurrent()
//		{
//			var request = this._sdkClient.CreateRequest()
//				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
//				.TransactionRequest()
//				.SetBasicFields(new TransactionBase
//				{
//					Currency = "EUR",
//					AmountDebit = 0.02m,
//					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
//					Description = "MAESTRO_PAYRECURRENT_SDK_UNITTEST",
//				})
//				.Maestro()
//				.PayRecurrent(new MaestroPayRecurrentRequest
//				{
//					//set properties
//				});

//			var response = request.Execute();
//		}

//		[TestMethod]
//		public void PayRemainder()
//		{
//			var request = this._sdkClient.CreateRequest()
//				.Authenticate(Constants.TestSettings.WebsiteKey, Constants.TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
//				.TransactionRequest()
//				.SetBasicFields(new TransactionBase
//				{
//					Currency = "EUR",
//					AmountDebit = 0.02m,
//					Invoice = $"SDK_TEST_{DateTime.Now.Ticks}",
//					Description = "MAESTRO_PAYREMAINDER_SDK_UNITTEST",
//				})
//				.Maestro()
//				.PayRemainder(new MaestroPayRemainderRequest
//				{
//					//set properties
//				});

//			var response = request.Execute();
//		}
//	}
//}
