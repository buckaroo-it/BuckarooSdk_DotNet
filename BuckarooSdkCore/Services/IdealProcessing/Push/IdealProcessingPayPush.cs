using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.IdealProcessing.Push
{
	public class IdealProcessingPayPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.IdealProcessing;

		public string ConsumerIban { get; set; }
		public string ConsumerBic { get; set; }
		public string ConsumerName { get; set; }
		public string ConsumerCity { get; set; }
		public string ConsumerAccountNumber { get; set; }
		public string ConsumerIssuer { get; set; }

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
