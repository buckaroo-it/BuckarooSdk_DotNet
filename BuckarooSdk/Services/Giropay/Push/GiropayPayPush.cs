using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Services.Giropay.Push
{
	public class GiropayPayPush : ActionResponse
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Giropay;

		/// <summary>
		/// The name of the issuer (bank) of the consumer.
		/// </summary>
		public string ConsumerBic { get; set; }
		public string ConsumerBankleitzahl { get; set; }
		public string ConsumerIBAN { get; set; }


	}
}
