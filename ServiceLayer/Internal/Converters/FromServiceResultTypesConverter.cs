using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class FromServiceResultTypesConverter : FromResultTypeConverter<ServiceResultTypes>
    {
        public override TDestinationResultType Convert<TDestinationResultType>(ServiceResultTypes sourceResultType)
        {
            FieldInfo enumField = GetEnumValueFieldWithResultTypeAttribute<TDestinationResultType>(sourceResultType);
            if (enumField == null)
            {
                throw new InvalidCastException($"Could not determine a suitable value of type {typeof(TDestinationResultType)} to convert the value \"{sourceResultType}\" of type {typeof(ServiceResultTypes)} to. Please ensure that values are annotated with appropriate \"Success\" and \"Failure\" attributes.");
            }
            TDestinationResultType destinationResultType = (TDestinationResultType)enumField?.GetValue(null);
            return destinationResultType;
        }

        private FieldInfo GetEnumValueFieldWithResultTypeAttribute<TDestinationResultType>(Enum resultType)
        {
            FieldInfo enumField = typeof(TDestinationResultType).GetTypeInfo()
                // Get all the fields of the given enum type. 
                .DeclaredFields
                // Match fields with their corresponding custom attribute of the given type.
                .ToDictionary(k => k, v =>
                {
                    var attributes = v.GetCustomAttributes<ResultTypeAttribute>(false);
                    var attribute = attributes.FirstOrDefault(a => Equals(a.ResultType, resultType));
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
