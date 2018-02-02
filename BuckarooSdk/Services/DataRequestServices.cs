using System.Collections.Generic;
using Newtonsoft.Json;

namespace BuckarooSdk.Services
{
	internal class DataRequestServices
	{
		/// <summary>
		/// A list of Services.
		/// </summary>
		[JsonProperty()]
		internal List<Service> ServiceList { get; set; }

		[JsonProperty()]
		internal List<Global> Global { get; set; }
		/// <summary>
		/// primary constructor. A new list of services is instantiated.
		/// </summary>
		internal DataRequestServices()
		{
			this.ServiceList = new List<Service>();
			this.Global = new List<Global>();
		}
	}
}
