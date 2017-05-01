using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.Specificiations
{
	public class SupportedCurrency
	{
		public int IsoNumber { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
	}
}
