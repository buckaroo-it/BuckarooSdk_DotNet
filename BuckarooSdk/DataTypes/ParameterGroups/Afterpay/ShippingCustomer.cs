using BuckarooSdk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.ParameterGroups.Afterpay
{
	public class ShippingCustomer : ParameterGroup
	{
		/// <summary>
		/// Personal info
		/// </summary>
		public string Category { get; set; }
		public string Salutation { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// address
		/// </summary>
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string StreetNumberAdditional { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }

		/// <summary>
		/// contact
		/// </summary>
		public string MobilePhone { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string CareOf { get; set; }
		public string ConversationLanguage { get; set; }
		public string IdentificationNumber { get; set; }
		public string CustomerNumber { get; set; }
	}
}
