using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.Services.IdealProcessing.TransactionRequest
{
	/// <summary>
	/// The idealrequest class, where the issuer of the request is specified.
	/// </summary>
	public class IdealProcessingPayRequest
	{
		/// <summary>
		/// Use constants in BuckarooSdk.Services.Ideal.IdealIssuer
		/// </summary>
		public string Issuer { get; set; }
	}
}
