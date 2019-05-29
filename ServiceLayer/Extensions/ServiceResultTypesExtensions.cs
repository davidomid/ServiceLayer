using System;
using System.Linq;
using System.Reflection;
using ServiceLayer.Attributes;
using ServiceLayer.Converters;

namespace ServiceLayer
{
    public static class ServiceResultTypesExtensions
    {
        public static TDestinationResultType ToResultType<TDestinationResultType>(this Enum resultType) where TDestinationResultType : struct, Enum
        {
            Type enumType = resultType.GetType();
            if (enumType == typeof(TDestinationResultType))
            {
                return (TDestinationResultType)resultType;
            }

            // Look for a converter for the specific source type and destination type. 
            IResultTypeConverter<TDestinationResultType> converter = ServiceResultConfiguration.ResultTypeConverters.Specific.Get<TDestinationResultType>(enumType);
            if (converter == null)
            {
                // If none is found, look for a general converter for the destination type.
                converter = ServiceResultConfiguration.ResultTypeConverters.General.Get<TDestinationResultType>();
                if (converter == null)
                {
                    throw new InvalidCastException($"No compatible converter was found for the source type {enumType} and destination type {typeof(TDestinationResultType)}.");
                }
            }

            TDestinationResultType? destinationResultType = converter.Convert(resultType);
            if (destinationResultType != null)
            {
                return destinationResultType.Value;
            }

            throw new InvalidCastException($"No valid enum value of type {typeof(TDestinationResultType)} could be found for the {enumType} value \"{resultType}\"");
        }
    }
}
