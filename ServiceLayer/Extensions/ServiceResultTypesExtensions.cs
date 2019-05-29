using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer
{
    public static class ServiceResultTypesExtensions
    {
        public static ServiceResultTypes ToServiceResultType(this Enum enumValue)
        {
            // todo move to a converter

            Type enumType = enumValue.GetType();
            if (enumType == typeof(ServiceResultTypes))
            {
                return (ServiceResultTypes) enumValue;
            }

            var name = Enum.GetName(enumType, enumValue);
            var successAttribute = enumType.GetTypeInfo().DeclaredFields
                .FirstOrDefault(p => p.Name == name)?
                .GetCustomAttributes(false)
                .OfType<SuccessAttribute>()
                .FirstOrDefault();

            if (successAttribute != null)
            {
                return ServiceResultTypes.Success;
            }

            return ServiceResultTypes.Failure; 
        }

        public static TDestinationResultType ToResultType<TSourceResultType, TDestinationResultType>(this TSourceResultType sourceResultType) where TSourceResultType : Enum where TDestinationResultType : Enum
        {
            if (typeof(TSourceResultType) == typeof(TDestinationResultType))
            {
                return (TDestinationResultType)(object)sourceResultType;
            }

            // todo migrate ServiceResultTypes conversion logic over to a separate converter class
            if (typeof(TSourceResultType) == typeof(ServiceResultTypes))
            {
                ServiceResultTypes serviceResultType = (ServiceResultTypes) (object) sourceResultType;
                return serviceResultType.ToResultType<TDestinationResultType>(); 
            }

            if (typeof(TDestinationResultType) == typeof(ServiceResultTypes))
            {
                ServiceResultTypes serviceResultType = sourceResultType.ToServiceResultType();
                return (TDestinationResultType)(object)serviceResultType;
            }

            // Look for a converter for the specific source type and destination type. 
            IResultTypeConverter<TDestinationResultType> converter = ServiceResultConfiguration.ResultTypeConverters.Get<TSourceResultType, TDestinationResultType>();
            if (converter == null)
            {
                // If none is found, look for a the general converter for the destination type.
                converter = ServiceResultConfiguration.ResultTypeConverters.Get<TDestinationResultType>();
                if (converter == null)
                {
                    throw new InvalidCastException($"No compatible converter was found for the source type {typeof(TSourceResultType)} and destination type {typeof(TDestinationResultType)}.");
                }
            }

            TDestinationResultType destinationResultType = converter.Convert(sourceResultType);
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
