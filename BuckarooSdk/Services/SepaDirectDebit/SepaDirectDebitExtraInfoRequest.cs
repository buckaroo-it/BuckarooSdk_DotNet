namespace BuckarooSdk.Services.SepaDirectDebit
{
    public class SepaDirectDebitExtraInfoRequest : SepaDirectDebitPayRequest
    {
        /// The customer ID, giving a unique ID to the customer for the merchant.
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// The customer referenceparty ID, giving a unique ID to the customer reference party for the merchant.
        /// </summary>
        public string CustomerReferencePartyCode { get; set; }
        /// <summary>
        /// The name of the customer reference party. (The person on whose behalf the customer is making a payment)
        /// </summary>
        public string CustomerReferencePartyName { get; set; }
        /// <summary>
        /// The street name of the customer.
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// The house number of the customer.
        /// </summary>
        public string HouseNumber { get; set; }
        /// <summary>
        /// 	The house number suffix of the customer.
        /// </summary>
        public string HouseNumberSuffix { get; set; }
        /// <summary>
        /// 	The zipcode of the customer.
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// The city of the customer.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 	The country of the customer.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 	The contract identifier for which the payment is being done.
        /// </summary>
        public string ContractId { get; set; }
    }
}
