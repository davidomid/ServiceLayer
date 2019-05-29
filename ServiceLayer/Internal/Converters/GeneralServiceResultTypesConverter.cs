using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class GeneralServiceResultTypesConverter : IResultTypeConverter<ServiceResultTypes>
    {
        public ServiceResultTypes? Convert(Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            if (enumType == typeof(ServiceResultTypes))
            {
                return (ServiceResultTypes)enumValue;
            }

            // We consider an enum value to represent a ServiceResultTypes.Success if the value has been tagged with a SuccessAttribute. 
            // Otherwise, it represents ServiceResultTypes.Failure.
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

        public TDestinationResultType? Convert<TDestinationResultType>(ServiceResultTypes resultType) where TDestinationResultType : struct, Enum
        {
            // todo move this to a converter
            if (typeof(TDestinationResultType) == typeof(ServiceResultTypes))
            {
                return (TDestinationResultType)(object)resultType;
            }

            FieldInfo enumField = GetEnumValueFieldForServiceResultType<TDestinationResultType>(resultType);

            if (enumField != null)
            {
                TDestinationResultType destinationResultType = (TDestinationResultType)enumField.GetValue(null);
                return destinationResultType;
            }

            return null;
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
