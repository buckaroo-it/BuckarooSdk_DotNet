using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Logging
{
	internal class BuckarooException : Exception
	{
		internal string ErrorMessage { get; set; }

		internal BuckarooException()
		{
			this.ErrorMessage = "unknown exception";
		}

		internal BuckarooException(string errorMessage)
		{
			this.ErrorMessage = errorMessage + this.Message;
		}
		
	}
}
