using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class FromServiceResultTypesConverter : FromResultTypeConverter<ServiceResultTypes>
    {
        public override Enum Convert(ServiceResultTypes sourceResultType)
        {
            FieldInfo enumField = GetEnumValueFieldForServiceResultType(sourceResultType);

            Enum destinationResultType = (Enum) enumField?.GetValue(null);
            return destinationResultType;
        }

        private FieldInfo GetEnumValueFieldForServiceResultType(ServiceResultTypes serviceResultType)
        {
            FieldInfo enumField;
            if (serviceResultType == ServiceResultTypes.Success)
            {
                enumField = GetEnumValueFieldWithAttribute<SuccessAttribute>();
            }
            else
            {
                enumField = GetEnumValueFieldWithAttribute<FailureAttribute>();
            }

            return enumField;
        }

        private FieldInfo GetEnumValueFieldWithAttribute<TAttributeType>() where TAttributeType : BaseAttribute
        {
            FieldInfo enumField = DestinationType.GetTypeInfo()
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
