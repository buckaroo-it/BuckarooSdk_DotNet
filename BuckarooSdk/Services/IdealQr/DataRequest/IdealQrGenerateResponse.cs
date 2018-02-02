using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Services.IdealQr.DataRequest
{
	public class IdealQrGenerateResponse : ActionResponse
	{
		public override ServiceEnum ServiceEnum => ServiceEnum.IdealQr;

		public string QrImageUrl { get; set; }
	}
}
