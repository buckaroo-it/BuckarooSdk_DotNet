using System;
using System.Collections.Generic;
using System.Text;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services.Giftcards.HuisTuinGiftcard
{
	public class HuisTuinGiftcardPayPush : ActionPush
	{
		public override ServiceNames ServiceNames => ServiceNames.HuisTuinGiftcard;
	}
}
