using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.IdealProcessing.TransactionRequest
{
	public class IdealProcessingPayResponse : ActionResponse
	{
		public override ServiceNames ServiceNames => ServiceNames.IdealProcessing;

		public string ConsumerIban { get; set; }
		public string ConsumerBic { get; set; }
		public string ConsumerName { get; set; }
		public string ConsumerCity { get; set; }
		public string ConsumerAccountNumber { get; set; }
		public string ConsumerIssuer { get; set; }

		public override void FillFromResponse(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromResponse(serviceResponse);
		}
	}
}
