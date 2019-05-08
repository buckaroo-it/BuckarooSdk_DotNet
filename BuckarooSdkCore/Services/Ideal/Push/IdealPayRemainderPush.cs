using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Ideal.Push
{
	/// <summary>
	/// 
	/// </summary>
	public class IdealPayRemainderPush : ActionPush
	{

		public override ServiceNames ServiceNames => ServiceNames.Ideal;

		/// <summary>
		/// 
		/// </summary>
		public string ConsumerIban { get; set; }
		public string ConsumerBic { get; set; }
		public string ConsumerName { get; set; }
		public string ConsumerIssuer { get; set; }
	}
}
