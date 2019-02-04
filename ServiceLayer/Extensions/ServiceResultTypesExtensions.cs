using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;

namespace ServiceLayer
{
    public static class ServiceResultTypesExtensions
    {
        public static ServiceResultTypes ToServiceResultType(this Enum enumValue)
        {
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

        public static TResultType ToResultType<TResultType>(this ServiceResultTypes serviceResultType)
        {
            FieldInfo enumField;
            if (serviceResultType == ServiceResultTypes.Success)
            {
                enumField = GetEnumValueField<TResultType, SuccessAttribute>();
            }
            else
            {
                enumField = GetEnumValueField<TResultType, FailureAttribute>();
            }

            if (enumField != null)
            {
                TResultType resultType = (TResultType)enumField.GetValue(null);
                return resultType;
            }

            throw new ArgumentException($"No valid enum value of type {typeof(TResultType)} could be found for the {typeof(ServiceResultTypes)} value \"{serviceResultType}\"");
        }

        private static FieldInfo GetEnumValueField<TResultType, TAttributeType>() where TAttributeType : BaseAttribute
        {
            Type enumType = typeof(TResultType);
            FieldInfo enumField = enumType.GetTypeInfo().DeclaredFields.OrderByDescending(f =>
            {
                var attribute = f.GetCustomAttribute<TAttributeType>(false);
                if (attribute != null)
                {
                    if (attribute.IsDefault)
                    {
                        return 2;
                    }
                    return 1;
                }
                return 0;
            }).FirstOrDefault();
            return enumField;
        }

    }
}
