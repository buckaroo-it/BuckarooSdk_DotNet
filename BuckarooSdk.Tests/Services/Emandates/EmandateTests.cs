using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Diagnostics;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Logging;
using BuckarooSdk.Services.Emandates.DataRequest;
using BuckarooSdk.Tests.Constants;

namespace BuckarooSdk.Tests.Services.Emandates
{
	[TestClass]
	public class EmandateTests
	{
		private SdkClient _buckarooClient;

		[TestInitialize]
		public void Setup()
		{
			this._buckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void CreateMandateTest()
		{
			var request = this._buckarooClient.CreateRequest(new StandardLogger()) // Create a request.
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest() // One of the request type options.
				.SetBasicFields(new DataBase
				{
					Currency = "EUR"
				})
				 // Choose the paymentmethod you want to use
				.Emandates()
				.CreateMandate(new EmandatesCreateMandateRequest()
				{
					Language = "nl",
					DebtorBankId = "INGBNL2A",
					DebtorReference = "klant1234",
					EmandateReason = "testing",
					PurchaseId = "purchaseid1234",
					SequenceType = "1",
				});

			var response = request.Execute();

			Process.Start(response.RequiredAction.RedirectURL);

			Console.WriteLine(response.BuckarooSdkLogger.GetFullLog());
		}

		public void ModifyMandate()
		{
			
		}

		public void CancelMandate()
		{
			
		}
	}
}