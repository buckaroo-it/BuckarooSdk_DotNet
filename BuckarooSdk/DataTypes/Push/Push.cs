using System;
using System.Collections.Generic;
using System.Linq;
using BuckarooSdk.DataTypes.Response.Status;
using BuckarooSdk.Services;

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

		public List<ServiceEnum> GetServices()
		{
			var services = new List<ServiceEnum>();
			foreach (var service in this.Services)
			{
				var serviceEnum = (ServiceEnum)Enum.Parse(typeof(ServiceEnum), service.Name, true);
				services.Add(serviceEnum);
			}

			return services;
		}

		// abstract class Response
		public T GetActionResponse<T>()
			where T : ActionPush, new()
		{
			var result = new T();

			var service = this.Services.FirstOrDefault(s => s.Name.Equals(result.ServiceEnum.ToString(), StringComparison.OrdinalIgnoreCase));
			if (service == null) return null;

			result.FillFromPush(service);

			return result;
		}
	}
}
