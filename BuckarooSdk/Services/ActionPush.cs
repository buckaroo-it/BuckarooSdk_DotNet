﻿using System;
using System.Linq;
using BuckarooSdk.DataTypes.Response;
using static BuckarooSdk.Constants.Services;

namespace BuckarooSdk.Services
{
    /// <summary>
    /// Action push.
    /// </summary>
    public abstract class ActionPush
    {
        /// <summary>
        /// Service names.
        /// </summary>
        public abstract ServiceNames ServiceNames { get; }

        internal virtual void FillFromPush(DataTypes.Response.Service servicePush)
        {
            var ownType = this.GetType();
            var publicProperties = ownType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var property in publicProperties)
            {
                var propertyName = property.Name;

                // TODO: Make dictionary/lookup?
                var parameter = this.GetParameter(servicePush, propertyName);

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
