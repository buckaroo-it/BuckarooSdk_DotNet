using System;
using System.Linq;
using BuckarooSdk.DataTypes.Response;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services
{
	public abstract class ActionResponse
	{
		public abstract ServiceNames ServiceNames { get; }

		public virtual void FillFromResponse(DataTypes.Response.Service serviceResponse)
		{
			var ownType = this.GetType();
			var publicProperties = ownType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

			foreach (var property in publicProperties)
			{
				var propertyName = property.Name;

				// TODO: Make dictionary/lookup?
				var parameter = this.GetParameter(serviceResponse, propertyName);

				if (parameter == null)
				{
					continue;
				}

				var convertedValue = this.ConvertValue(parameter.Value, property.PropertyType);
				property.SetValue(this, convertedValue);
			}
		}

		protected ResponseParameter GetParameter(DataTypes.Response.Service serviceResponse, string parameterName)
		{
			return serviceResponse.Parameters.FirstOrDefault(param => param.Name.Equals(parameterName, StringComparison.OrdinalIgnoreCase));
		}

		protected T ConvertValue<T>(string value)
		{
			return (T)this.ConvertValue(value, typeof(T));
		}

		protected object ConvertValue(string value, Type toType)
		{
			return Convert.ChangeType(value, toType);
		}
	}
}
