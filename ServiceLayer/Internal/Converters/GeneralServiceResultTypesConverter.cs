using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class GeneralServiceResultTypesConverter : IResultTypeConverter<ServiceResultTypes>
    {
        public ServiceResultTypes Convert(Enum enumValue)
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

    }
}
