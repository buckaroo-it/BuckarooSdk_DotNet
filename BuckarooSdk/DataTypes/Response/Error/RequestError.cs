using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.Error
{
	public class RequestError
	{
		public string Type => this.GetType().Name;
	}
}
