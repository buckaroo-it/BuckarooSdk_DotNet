using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Services.Afterpay.Push
{
	public class AfterpayAuthorizePush : ActionPush
	{
		public override Constants.Services.ServiceNames ServiceNames => Constants.Services.ServiceNames.Afterpay;

		internal override void FillFromPush(DataTypes.Response.Service serviceResponse)
		{
			base.FillFromPush(serviceResponse);
		}
	}
}
