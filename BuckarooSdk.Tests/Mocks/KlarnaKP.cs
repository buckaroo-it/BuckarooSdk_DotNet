using BuckarooSdk.DataTypes.ParameterGroups.Klarna;
using BuckarooSdk.Services;
using BuckarooSdk.Services.KlarnaKP;

namespace BuckarooSdk.Tests.Mocks
{
	internal class KlarnaKP
	{
		internal static KlarnaReserveRequest KlarnaKpReserveMock => new KlarnaReserveRequest()
		{
			Gender = 1, //mandatory
			OperatingCountry = "NL", // Mandatory
			Pno = "03061992", // Mandatory

			//billing
			BillingCompanyName = "Buckaroo",
			BillingFirstName = "JJA",
			BillingLastName = "Roos",
			BillingEmail = "s.roos@buckaroo.nl",
			BillingStreet = "Zonnebaan",
			BillingHouseNumber = "9",
			BillingHouseNumberSuffix = string.Empty,
			BillingPostalCode = "3542 EA",
			BillingCountry = "NL",
			BillingCellPhoneNumber = "0613575514",
			BillingCity = "Utrecht",
			BillingPhoneNumber = string.Empty,
			BillingCareOf = string.Empty,

			//shipping
			ShippingSameAsBilling = true, //if true, shipping part can be skipped.

			ShippingCountry = string.Empty,
			ShippingCity = string.Empty,
			ShippingCompany = string.Empty,
			ShippingLastName = string.Empty,
			ShippingCellPhoneNumber = string.Empty,
			ShippingFirstName = string.Empty,
			ShippingHouseNumberSuffix = string.Empty,
			ShippingPostalCode = string.Empty,
			ShippingStreet = string.Empty,
			ShippingHouseNumber = string.Empty,
			ShippingEmail = string.Empty,
			ShippingCareOf = string.Empty,
			ShippingPhoneNumber = string.Empty,

			//Articles = articles
			Articles = new ParameterGroupCollection<Article>("Article")
			{
				new Article()
				{
					ArticleTitle = "foo1",
					ArticleNumber = "123",
					ArticlePrice = 0.1m,
					ArticleQuantity = 2,
					ArticleVat = 21
				},
				new Article()
				{
					ArticleTitle = "foo2",
					ArticleNumber = "456",
					ArticlePrice = 0.2m,
					ArticleQuantity = 1,
					ArticleVat = 21
				},

			}
		};

		internal static KlarnaCancelReservationRequest KlarnaKpCancelReservationMock => new KlarnaCancelReservationRequest()
		{
			ReservationNumber = "38ade936-e9b9-7dba-94e1-d0fda0425a1d",
		};

		internal static KlarnaUpdateReservationRequest KlarnaKpUpdateReservationMock => new KlarnaUpdateReservationRequest()
		{
			ReservationNumber = "26a709d5-97ff-79b1-a805-b1b3c38cfef1",
			
			//billing
			BillingCompanyName = "Buckaroo",
			BillingFirstName = "JJA",
			BillingLastName = "Roos",
			BillingEmail = "s.roos@buckaroo.nl",
			BillingStreet = "Zonnebaan",
			BillingHouseNumber = "9",
			BillingHouseNumberSuffix = string.Empty,
			BillingPostalCode = "3542 EA",
			BillingCountry = "NL",
			BillingCellPhoneNumber = "0613575514",
			BillingCity = "Utrecht",
			BillingPhoneNumber = string.Empty,
			BillingCareOf = string.Empty,

			//shipping
			ShippingSameAsBilling = true, //if true, shipping part can be skipped.

			Articles = new ParameterGroupCollection<Article>("Article")
			{
				new Article()
				{
					ArticleTitle = "foo1",
					ArticleNumber = "123",
					ArticlePrice = 0.1m,
					ArticleQuantity = 1,
					ArticleVat = 21
				},
				new Article()
				{
					ArticleTitle = "foo2",
					ArticleNumber = "456",
					ArticlePrice = 0.2m,
					ArticleQuantity = 1,
					ArticleVat = 21
				},

			}
		};

		internal static KlarnaPayRequest KlarnaKpPayMock => new KlarnaPayRequest()
		{
			ReservationNumber = "22a84ff4-9232-7d08-8541-037d88a3fff3", // Mandatory

			// Article(s) optional. used for partial payments. 

			//Article = new Article
			//{
			//	ArticleQuantity = 0,
			//	ArticleNumber = string.Empty,
			//}
		};

		internal static KlarnaRefundRequest KlarnaKpRefundMock => new KlarnaRefundRequest()
		{
			// no servicespecific variables required. Only the originalTransactionKey
		};
	}
}
