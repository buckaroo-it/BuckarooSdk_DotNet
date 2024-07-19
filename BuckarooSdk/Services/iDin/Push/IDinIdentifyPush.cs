using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.iDin.Push
{
    public class IDinIdentifyPush : ActionPush
    {
        public override ServiceNames ServiceNames => ServiceNames.IDin;

        /// <summary>
        /// The gender of the customer.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The last name of the customer.
        /// </summary>
        public string LegalLastName { get; set; }

        /// <summary>
        /// The initials of the customer.
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The date of birth of the customer.
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// The phone number of the customer.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The BIN (Bank Identification Number) of the customer.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// The street name of the customer's address.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The house number of the customer's address.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// The postal code of the customer's address.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The city of the customer's address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The country code of the customer's address.
        /// </summary>
        public string Country { get; set; }
    }
}
