using BuckarooSdk.Constants;
using BuckarooSdk.Services;

using System;
using System.Collections.Generic;
using System.Text;

namespace BuckarooSdkCore.Services.ApplePay.TransactionRequest
{
	public class ApplePayPayResponse : ActionResponse
	{
		public override BuckarooSdk.Constants.Services.ServiceNames ServiceNames => BuckarooSdk.Constants.Services.ServiceNames.ApplePay;
	}
}
