using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk
{
	public interface ICreditcardNumber
	{
		string Number { get; set; }
	}

	public class VPayCreditcardNumber : ICreditcardNumber
	{
		public string Number { get; set; }
	}
}
