using BuckarooSdk.DataTypes.ParameterGroups.Klarna;
using BuckarooSdk.Services;
using BuckarooSdk.Services.KlarnaKP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Tests.Mocks
{
	internal class KlarnaKP
	{
		internal static KlarnaReserveRequest KlarnaKpReserveMock => new KlarnaReserveRequest()
		{
			Gender = 0,
			OperatingCountry = "NL", // Mandatory
			Pno = "12345678", // Mandatory

			//billing
			BillingPhoneNumber = string.Empty,
			BillingHouseNumber = string.Empty,
			BillingCompanyName = string.Empty,
			BillingLastName = string.Empty,
			BillingHouseNumberSuffix = string.Empty,
			BillingEmail = string.Empty,
			BillingCareOf = string.Empty,
			BillingStreet = string.Empty,
			BillingPostalCode = string.Empty,
			BillingCountry = string.Empty,
			BillingCellPhoneNumber = string.Empty,
			BillingCity = string.Empty,
			BillingFirstName = string.Empty,

			//shipping
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
			ShippingSameAsBilling = false,
			ShippingEmail = string.Empty,
			ShippingCareOf = string.Empty,
			ShippingPhoneNumber = string.Empty,

			//Articles = articles
			Articles = new ParameterGroupCollection<Article>("Article")
			{
				new Article()
				{
					ArticleTitle = "foo1",
				},
				new Article()
				{
					ArticleTitle = "foo2",
				},
				new Article()
				{
					ArticleTitle = "foo3",
				}
			}
		};

		internal static KlarnaCancelReservationRequest KlarnaKpCancelReservationMock => new KlarnaCancelReservationRequest()
		{
			ReservationNumber = "",
		};

		internal static KlarnaUpdateReservationRequest KlarnaKpUpdateReservationMock => new KlarnaUpdateReservationRequest()
		{
			ReservationNumber = "",
			//billing
			BillingPhoneNumber = string.Empty,
			BillingHouseNumber = string.Empty,
			BillingCompanyName = string.Empty,
			BillingLastName = string.Empty,
			BillingHouseNumberSuffix = string.Empty,
			BillingEmail = string.Empty,
			BillingCareOf = string.Empty,
			BillingStreet = string.Empty,
			BillingPostalCode = string.Empty,
			BillingCountry = string.Empty,
			BillingCellPhoneNumber = string.Empty,
			BillingCity = string.Empty,
			BillingFirstName = string.Empty,

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
			ShippingSameAsBilling = false,
			ShippingEmail = string.Empty,
			ShippingCareOf = string.Empty,
			ShippingPhoneNumber = string.Empty,


		};
	}

}
