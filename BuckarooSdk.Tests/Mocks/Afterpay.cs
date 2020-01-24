using BuckarooSdk.DataTypes.ParameterGroups.Afterpay;
using BuckarooSdk.Services.Afterpay;
using System;

namespace BuckarooSdk.Tests.Mocks
{
	internal class Afterpay
	{
		internal static AfterpayAuthorizeRequest AfterpayAuthorizeMock => new AfterpayAuthorizeRequest()
		{
			MerchantImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
			SummaryImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
			BankAccount = "NL13TEST0123456789",
			BankCode = "TESTNL2A",

			BillingCustomer = new BillingCustomer()
			{
				Category = "Person",
				Salutation = "Mr",
				FirstName = "J.",
				LastName = "de Tester",
				BirthDate = new DateTime(1992, 6, 3),
				Street = "Zonnebaan",
				StreetNumber = "9",
				StreetNumberAdditional = "",
				PostalCode = "3542 EA",
				City = "UTRECHT",
				Country = "NL",
				MobilePhone = "0612345678",
				Phone = "0713613412",
				Email = "s.roos@buckaroo.nl",
				CareOf = "",
				ConversationLanguage = "",
				IdentificationNumber = "",
				CustomerNumber = "John Smith",
			},
			//ShippingCustomer = new ShippingCustomer()
			//{
			//	Category = "",
			//	Salutation = "",
			//	FirstName = "",
			//	LastName = "",
			//	BirthDate = new DateTime(1992, 6, 3),
			//	Street = "",
			//	StreetNumber = "",
			//	StreetNumberAdditional = "",
			//	PostalCode = "",
			//	City = "",
			//	Country = "",
			//	MobilePhone = "",
			//	Phone = "",
			//	Email = "",
			//	CareOf = "",
			//	ConversationLanguage = "",
			//	IdentificationNumber = "",
			//	CustomerNumber = "",
			//},
			Articles = new BuckarooSdk.Services.ParameterGroupCollection<Article>("Article")
			{
				new Article()
				{
					Description = "Blue Toy Car",
					GrossUnitPrice = "2.00",
					VatPercentage = "21",
					Quantity = 1,
					Identifier = "Articlenumber12345",
					ImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
					Url = "https://www.buckaroo.nl/",
					Type = "PhysicalArticle",
				}
			}

		};

		internal static AfterpayCancelAuthorizeRequest AfterpayCancelAuthorizeMock => new AfterpayCancelAuthorizeRequest()
		{
			//no actionparameters
		};

		internal static AfterpayCaptureRequest AfterpayCaptureMock => new AfterpayCaptureRequest()
		{
			

		};

		internal static AfterpayPayRequest AfterpayPayMock => new AfterpayPayRequest()
		{
			MerchantImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
			SummaryImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
			BankAccount = "NL13TEST0123456789",
			BankCode = "TESTNL2A",

			BillingCustomer = new BillingCustomer()
			{
				Category = "Person",
				Salutation = "Mr",
				FirstName = "J.",
				LastName = "de Tester",
				BirthDate = new DateTime(1992, 6, 3),
				Street = "Zonnebaan",
				StreetNumber = "9",
				StreetNumberAdditional = "",
				PostalCode = "3542 EA",
				City = "UTRECHT",
				Country = "NL",
				MobilePhone = "0612345678",
				Phone = "0713613412",
				Email = "s.roos@buckaroo.nl",
				CareOf = "",
				ConversationLanguage = "",
				IdentificationNumber = "",
				CustomerNumber = "John Smith",
			},
			//ShippingCustomer = new ShippingCustomer()
			//{
			//	Category = "",
			//	Salutation = "",
			//	FirstName = "",
			//	LastName = "",
			//	BirthDate = new DateTime(1992, 6, 3),
			//	Street = "",
			//	StreetNumber = "",
			//	StreetNumberAdditional = "",
			//	PostalCode = "",
			//	City = "",
			//	Country = "",
			//	MobilePhone = "",
			//	Phone = "",
			//	Email = "",
			//	CareOf = "",
			//	ConversationLanguage = "",
			//	IdentificationNumber = "",
			//	CustomerNumber = "",
			//},
			Articles = new BuckarooSdk.Services.ParameterGroupCollection<Article>("Article")
			{
				new Article()
				{
					Description = "Blue Toy Car",
					GrossUnitPrice = "2.00",
					VatPercentage = "21",
					Quantity = 1,
					Identifier = "Articlenumber12345",
					ImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
					Url = "https://www.buckaroo.nl/",
					Type = "PhysicalArticle",
				}
			}

		};

		internal static AfterpayRefundRequest AfterpayRefundMock => new AfterpayRefundRequest()
		{
			Articles = new BuckarooSdk.Services.ParameterGroupCollection<Article>("Article")
			{
				new Article()
				{
					Description = "Blue Toy Car",
					GrossUnitPrice = "10.00",
					VatPercentage = "21",
					Quantity = 1,
					Identifier = "Articlenumber12345",
					ImageUrl = "https://www.buckaroo.nl/img/logo_menu.png",
					Url = "https://www.buckaroo.nl/",
					Type = "Physical",
				}
			}
		};
	}
}

