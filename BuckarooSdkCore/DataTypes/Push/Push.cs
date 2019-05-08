using System;
using System.Collections.Generic;
using System.Linq;
using BuckarooSdk.DataTypes.Response.Status;
using BuckarooSdk.Services;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.DataTypes.Push
{
	public abstract class Push
	{
		/// <summary>
		/// The transaction key
		/// </summary>
		public string Key { get; set; }
		/// <summary>
		/// The status of the transaction
		/// </summary>
		public Status Status { get; set; }
		/// <summary>
		/// The list of services that were available for the transaction request
		/// </summary>
		public List<Response.Service> Services { get; set; }

		public List<ServiceNames> GetServices()
		{
			return this.Services.Select(service => (ServiceNames) Enum.Parse(typeof(ServiceNames), service.Name, true)).ToList();
		}

		// abstract class Response
		public T GetActionResponse<T>()
			where T : ActionPush, new()
		{
			var result = new T();

			var service = this.Services.FirstOrDefault(s => s.Name.Equals(result.ServiceNames.ToString(), StringComparison.OrdinalIgnoreCase));
			if (service == null) return null;

			result.FillFromPush(service);

			return result;
		}
	}
}
