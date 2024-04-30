using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.Push
{
    public class IdealPayFastCheckoutPush : ActionPush
    {
        public override ServiceNames ServiceNames => ServiceNames.Ideal;

        /// <summary>
        /// This is the iDEAL transaction ID.
        /// </summary>
        public string Transactionid { get; set; }

        /// <summary>
        /// The international bank account number (iban code) of the bank of the consumer. Please note: This field is optional. 
        /// In some countries, banks are not allowed to provide this information to third parties.
        /// </summary>
        public string ConsumerIban { get; set; }

        /// <summary>
        /// The bank identifier (bic code) of the bank of the consumer. Please note: This field is optional. In some countries, 
        /// banks are not allowed to provide this information to third parties.
        /// </summary>
        public string ConsumerBic { get; set; }

        /// <summary>
        /// The beneficiary of the bank account from which the payment was made.
        /// </summary>
        public string ConsumerName { get; set; }

        /// <summary>
        /// The name of the issuer (bank) of the consumer.
        /// </summary>
        public string ConsumerIssuer { get; set; }

        /// <summary>
        /// The first name of the contact person.
        /// </summary>
        public string ContactDetailsFirstName { get; set; }

        /// <summary>
        /// The last name of the contact person.
        /// </summary>
        public string ContactDetailsLastName { get; set; }

        /// <summary>
        /// The phone number of the contact person.
        /// </summary>
        public string ContactDetailsPhoneNumber { get; set; }

        /// <summary>
        /// The email address of the contact person.
        /// </summary>
        public string ContactDetailsEmail { get; set; }

        /// <summary>
        /// The first name of the recipient for shipping.
        /// </summary>
        public string ShippingAddressFirstName { get; set; }

        /// <summary>
        /// The last name of the recipient for shipping.
        /// </summary>
        public string ShippingAddressLastName { get; set; }

        /// <summary>
        /// The company name for shipping address.
        /// </summary>
        public string ShippingAddressCompanyName { get; set; }

        /// <summary>
        /// The postal code for shipping address.
        /// </summary>
        public string ShippingAddressPostalCode { get; set; }

        /// <summary>
        /// Addition for shipping address.
        /// </summary>
        public string ShippingAddressAddition { get; set; }

        /// <summary>
        /// The house number for shipping address.
        /// </summary>
        public string ShippingAddressHouseNumber { get; set; }

        /// <summary>
        /// The street for shipping address.
        /// </summary>
        public string ShippingAddressStreet { get; set; }

        /// <summary>
        /// The city for shipping address.
        /// </summary>
        public string ShippingAddressCity { get; set; }

        /// <summary>
        /// The country name for shipping address.
        /// </summary>
        public string ShippingAddressCountryName { get; set; }

        /// <summary>
        /// The first name of the recipient for invoice.
        /// </summary>
        public string InvoiceAddressFirstName { get; set; }

        /// <summary>
        /// The last name of the recipient for invoice.
        /// </summary>
        public string InvoiceAddressLastName { get; set; }

        /// <summary>
        /// The company name for invoice address.
        /// </summary>
        public string InvoiceAddressCompanyName { get; set; }

        /// <summary>
        /// The postal code for invoice address.
        /// </summary>
        public string InvoiceAddressPostalCode { get; set; }

        /// <summary>
        /// Addition for invoice address.
        /// </summary>
        public string InvoiceAddressAddition { get; set; }

        /// <summary>
        /// The house number for invoice address.
        /// </summary>
        public string InvoiceAddressHouseNumber { get; set; }

        /// <summary>
        /// The street for invoice address.
        /// </summary>
        public string InvoiceAddressStreet { get; set; }

        /// <summary>
        /// The city for invoice address.
        /// </summary>
        public string InvoiceAddressCity { get; set; }

        /// <summary>
        /// The country name for invoice address.
        /// </summary>
        public string InvoiceAddressCountryName { get; set; }

        internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
        {
            base.FillFromPush(serviceResponse);
        }
    }
}
