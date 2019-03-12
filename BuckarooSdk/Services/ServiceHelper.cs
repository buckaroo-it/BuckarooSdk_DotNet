using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Reflection;

namespace BuckarooSdk.Services
{
	internal static class ServiceHelper
	{
		internal static List<RequestParameter> CreateServiceParameters(object request, string serviceName = "")
		{
			return CreateServiceParametersImplementation(request, serviceName);
		}

		private static List<RequestParameter> CreateServiceParametersImplementation(object fullOrPartialRequest, string serviceName, string groupName = "", string groupId = "")
		{
			var result = new List<RequestParameter>();

			var properties = fullOrPartialRequest.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
				.Where(property => property.Name != nameof(IParameterGroup.GroupName))
				.ToList();

			foreach (var property in properties)
			{
				var propertyValue = property.GetValue(fullOrPartialRequest);

				if (propertyValue == null)
				{
					continue;
				}

				// Group with EVERY PARAM MaxOccurs > 1:
				// Recurse into this method for each item
				if (propertyValue is IParameterGroupCollection)
				{
					var groupValue = propertyValue as IParameterGroupCollection;
					var i = 1;
					foreach (var item in groupValue)
					{
						var subResult = CreateServiceParametersImplementation(groupValue, serviceName, groupValue.GroupName, i.ToString());
						result.AddRange(subResult);
						i++;
					}
				}

				// Group:
				// Recurse into this method
				else if (propertyValue is IParameterGroup)
				{
					var groupValue = propertyValue as IParameterGroup;
					var subResult = CreateServiceParametersImplementation(groupValue, serviceName, groupValue.GroupName, groupId);
					result.AddRange(subResult);
				}

				// No group, but MaxOccurs > 1:
				// Make param for each item
				else if (propertyValue is System.Collections.IEnumerable && !(propertyValue is string))
				{
					var collectionValue = propertyValue as System.Collections.IEnumerable;
					var i = 1;
					foreach (var item in collectionValue)
					{
						var propertyName = PropertyName(serviceName.ToString(), property);
						result.Add(CreateParameter(item, propertyName, groupName, i.ToString()));
						i++;
					}
				}

				// No group, MaxOccurs = 1 (simple parameter):
				// Make param for this item
				else
				{
					var propertyName = PropertyName(serviceName.ToString(), property);
					result.Add(CreateParameter(propertyValue, propertyName, groupName));
				}
			}

			return result;
		}

		private static string PropertyName(string serviceName, PropertyInfo property)
		{
			var propertyName = property.Name;

			if (property.Name == "CreditcardNumber")
			{
				switch (serviceName.ToLower())
				{
					case "vpay":
						propertyName = "VPayCreditcardNumber";
						break;
				}
			}

			return propertyName;
		}

		private static RequestParameter CreateParameter(object value, string name, string groupName = "", string groupId = "")
		{
			return new RequestParameter()
			{
				Name = name,
				Value = StringifyParameter(value),
				GroupType = groupName,
				GroupId = groupId,
			};
		}

		private static string StringifyParameter(object value)
		{
			if (value is decimal)
			{
				return ((decimal)value).ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				return value?.ToString();
			}
		}
	}
}
