using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuckarooSdk.Base;
using BuckarooSdk.Services;

namespace BuckarooSdk
{
	public interface IRequestObject
	{
		/// <summary>
		/// The currency of the transaction.
		/// </summary>
		string Currency { get; set; }

		/// <summary>
		/// The base transaction info
		/// </summary>
		IRequestObject RequestObjectBase { get; set; }

		AuthenticatedRequest AuthenticatedRequest { get; set; }
		List<Service> Services { get; set; }

		void AddService(string serviceName, List<RequestParameter> parameters, string action, string version = "1");
	}
}
