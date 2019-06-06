using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;

namespace ServiceLayer.Converters
{
    public class DefaultResultTypeConverter : ResultTypeConverter
    {
        public DefaultResultTypeConverter() : base(null, null)
        {
        }

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            // Check if there is an attribute on the source result type value which maps is to the destination type.
            Enum destinationValue = GetDestinationValueByDestinationValueResultTypeAttributeOnSourceValue(sourceResultType,
                    destinationEnumType);

            if (destinationValue != null)
            {
                return destinationValue;
            }

            // If no attribute is found, check the destination type to see if there's an attribute for mapping from the source result type
            // on any of the fields. If there is, use the value of that field. 
            // If there are multiple values, use the default one. 
            destinationValue =
                GetDestinationValueBySourceValueResultTypeAttributeForValueOfDestinationType(sourceResultType,
                    destinationEnumType);

            if (destinationValue != null)
            {
                return destinationValue;
            }

            // If no attribute can be found, try to find a default destination value by checking for a DefaultResultType attribute on the destination type.
            destinationValue = GetDestinationValueByDefaultResultTypeAttributeForValueOnDestinationType(destinationEnumType);

            if (destinationValue == null)
            {
                // If a destination value still can't be determined, throw an exception.
                throw new InvalidCastException($"Could not determine a suitable value of type {destinationEnumType} to convert the value \"{sourceResultType}\" of type {sourceResultType.GetType()} to. Please ensure that either the source or destination values are annotated with appropriate \"ResultType\" attributes, or implement a custom converter.");
            }

            return destinationValue;
        }

        private Enum GetDestinationValueByDefaultResultTypeAttributeForValueOnDestinationType(Type destinationEnumType)
        {
            var destinationValueField = destinationEnumType
                .GetTypeInfo()
                .DeclaredFields
                .FirstOrDefault(f =>
                {
                    var defaultResultTypeAttribute = f.GetCustomAttribute<DefaultResultTypeAttribute>(false);
                    return defaultResultTypeAttribute != null;
                }); 

            Enum destinationValue = (Enum)destinationValueField?.GetValue(null);
            return destinationValue;
        }

        private Enum GetDestinationValueByDestinationValueResultTypeAttributeOnSourceValue(Enum sourceResultType, Type destinationEnumType)
        {
            Type sourceType = sourceResultType.GetType();

            var name = Enum.GetName(sourceType, sourceResultType);
            var destinationValueAttribute = sourceType.GetTypeInfo().DeclaredFields
                .FirstOrDefault(p => p.Name == name)?
                .GetCustomAttributes<ResultTypeAttribute>(false)
                .FirstOrDefault(a => a.ResultType.GetType() == destinationEnumType);

            return destinationValueAttribute?.ResultType;
        }

        private Enum GetDestinationValueBySourceValueResultTypeAttributeForValueOfDestinationType(Enum sourceResultType, Type destinationEnumType)
        {
            FieldInfo destinationValueField = destinationEnumType.GetTypeInfo()
                // Get all the fields of the given enum type. 
                .DeclaredFields
                // Match fields with their corresponding custom attribute of the given type.
                .ToDictionary(k => k, v =>
                {
                    var attributes = v.GetCustomAttributes<ResultTypeAttribute>(false);
                    var attribute = attributes.FirstOrDefault(a => Equals(a.ResultType, sourceResultType));
                    return attribute;
                })
                // Only retrieve fields with a custom attribute.
                .Where(kvp => kvp.Value != null)
                // Order the fields in descending order, by the IsDefault property of the attribute, then take the first field.
                .OrderByDescending(kvp => kvp.Value.IsDefault)
                .FirstOrDefault().Key;

            Enum destinationValue = (Enum) destinationValueField?.GetValue(null);
            return destinationValue;
        }
    }
}
