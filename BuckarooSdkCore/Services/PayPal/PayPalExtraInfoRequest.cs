namespace BuckarooSdk.Services.PayPal
{
    public class PayPalExtraInfoRequest
    {
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string CityName { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int NoShipping { get; set; }
        public bool AddressOverride { get; set; }
    }
}
