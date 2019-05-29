using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer
{
    public static class ServiceResultTypesExtensions
    {
        public static TDestinationResultType ToResultType<TDestinationResultType>(this Enum resultType) where TDestinationResultType : Enum
        {
            Type enumType = resultType.GetType();
            if (enumType == typeof(TDestinationResultType))
            {
                return (TDestinationResultType)(object)resultType;
            }

            // todo migrate ServiceResultTypes conversion logic over to a separate converter class
            if (enumType == typeof(ServiceResultTypes))
            {
                ServiceResultTypes serviceResultType = (ServiceResultTypes)resultType;
                return serviceResultType.ToResultType<TDestinationResultType>(); 
            }

            // Look for a converter for the specific source type and destination type. 
            IResultTypeConverter<TDestinationResultType> converter = ServiceResultConfiguration.ResultTypeConverters.Specific.Get<TDestinationResultType>(enumType);
            if (converter == null)
            {
                // If none is found, look for a the general converter for the destination type.
                converter = ServiceResultConfiguration.ResultTypeConverters.General.Get<TDestinationResultType>();
                if (converter == null)
                {
                    throw new InvalidCastException($"No compatible converter was found for the source type {enumType} and destination type {typeof(TDestinationResultType)}.");
                }
            }

            TDestinationResultType destinationResultType = converter.Convert(resultType);
            return destinationResultType;
        }

        public static TResultType ToResultType<TResultType>(this ServiceResultTypes serviceResultType) where TResultType : Enum
        {
            // todo move this to a converter

            if (typeof(TResultType) == typeof(ServiceResultTypes))
            {
                return (TResultType)(object)serviceResultType;
            }

            FieldInfo enumField = GetEnumValueFieldForServiceResultType<TResultType>(serviceResultType); 

            if (enumField != null)
            {
                TResultType resultType = (TResultType)enumField.GetValue(null);
                return resultType;
            }

            throw new ArgumentException($"No valid enum value of type {typeof(TResultType)} could be found for the {typeof(ServiceResultTypes)} value \"{serviceResultType}\"");
        }

        private static FieldInfo GetEnumValueFieldForServiceResultType<TResultType>(ServiceResultTypes serviceResultType) where TResultType : Enum
        {
            // todo move to a converter

            FieldInfo enumField;
            if (serviceResultType == ServiceResultTypes.Success)
            {
                enumField = GetEnumValueFieldWithAttribute<TResultType, SuccessAttribute>();
            }
            else
            {
                enumField = GetEnumValueFieldWithAttribute<TResultType, FailureAttribute>();
            }

            return enumField; 
        }

        private static FieldInfo GetEnumValueFieldWithAttribute<TResultType, TAttributeType>() where TResultType : Enum where TAttributeType : BaseAttribute 
        {
            // todo move to a converter

            FieldInfo enumField = typeof(TResultType).GetTypeInfo()
            // Get all the fields of the given enum type. 
            .DeclaredFields
            // Match fields with their corresponding custom attribute of the given type.
            .ToDictionary(k => k, v => 
            {
                var attribute = v.GetCustomAttribute<TAttributeType>(false);
                return attribute;
            })
            // Only retrieve fields with a custom attribute.
            .Where(kvp => kvp.Value != null)
            // Order the fields in descending order, by the IsDefault property of the attribute, then take the first field.
            .OrderByDescending(kvp => kvp.Value.IsDefault)
            .FirstOrDefault().Key; 

            return enumField;
        }

    }
}
