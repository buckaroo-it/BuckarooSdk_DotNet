using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.Response.StatusRequest
{
	public class InvalidTransaction
	{
		public string Key { get;set; }
		public string Invoice { get; set; }
		public CustomParameter CustomParameter { get;set; }
		public CustomParameter AdditionParameter { get; set; }
		public string ErrorMessage { get; set; }
	}
}
