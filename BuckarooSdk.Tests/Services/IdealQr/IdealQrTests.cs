using System;
using System.Diagnostics;
using System.Globalization;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services.IdealQr.DataRequest;
using BuckarooSdk.Tests.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckarooSdk.Tests.Services.IdealQr
{
	[TestClass]
	public class IdealQrTests
	{
		public SdkClient BuckarooClient { get; private set; }

		[TestInitialize]
		public void Setup()
		{
			this.BuckarooClient = new SdkClient(TestSettings.Logger);
		}

		[TestMethod]
		public void GenerateTest()
		{
			var request = this.BuckarooClient.CreateRequest()
				.Authenticate(TestSettings.WebsiteKey, TestSettings.SecretKey, false, new CultureInfo("nl-NL"))
				.DataRequest()
				.SetBasicFields(new DataBase())
				.IdealQr()
				.Generate(new IdealQrGenerateRequest()
				{
					Amount = 0.02m,
					Description = "Dit is de description.",
					Expiration = DateTime.Now.AddDays(4),
					AmountIsChangeable = true,
					MinAmount = 0.02m,
					MaxAmount = 0.05m,
					ImageSize = 250,
					PurchaseId = "purchaseId",
					IsOneOff = true,
					IsProcessing = false,
				});

			var response = request.Execute();

			var rawRequest = response.BuckarooSdkLogger.GetRawRequest();

			var actionResponse = response.GetActionResponse<IdealQrGenerateResponse>();

			var qrImageUrl = actionResponse.QrImageUrl;

			//From this point on a Merchant can do anything he wants with a qr. He can save the link if it is later on used in an email 
			//or printed on a sticker or poster. He can also return it and place it in a <img> tag on a website. In this example I run 
			//just the image url to confirm that is returns a legit image of an iDEAL QR image.

			if (response.Status.Code.Code == BuckarooSdk.Constants.Status.Success)
			{
				Process.Start(actionResponse.QrImageUrl);
			}
		}
	}
}
