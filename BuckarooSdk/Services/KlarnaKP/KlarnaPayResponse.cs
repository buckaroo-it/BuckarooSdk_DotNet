namespace BuckarooSdk.Services.KlarnaKP
{
	public class KlarnaPayResponse : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.KlarnaKP;

		public string InvoiceNumber { get; set; }
	}
}
