namespace BuckarooSdk.Services.PayPal
{
    public class PayPalExtraInfoResponse : ActionResponse
    {
	    public override ServiceEnum ServiceEnum => ServiceEnum.PayPal;
        public string SelectedName { get; set; }
        public string SelectedStreet1 { get; set; }
        public string SelectedStreet2 { get; set; }
        public string SelectedCityName { get; set; }
        public string SelectedStateOrProvince { get; set; }
        public string SelectedPostalCode { get; set; }
        public string SelectedCountry { get; set; }
        public string AddressStatus { get; set; }
        public string ProtectionEligibility { get; set; }
        public string ProtectionEligibilityType { get; set; }
    }
}
