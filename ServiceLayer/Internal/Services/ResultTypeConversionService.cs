using System;
using System.Linq;

namespace ServiceLayer.Internal.Services
{
    internal class ResultTypeConversionService : IResultTypeConversionService
    {
        public TDestinationResultType Convert<TDestinationResultType>(Enum sourceResultType)
            where TDestinationResultType : struct, Enum
        {
            Type sourceType = sourceResultType.GetType();

            var installedResultTypeConverters = Engine.ResultTypeConverters.Installed;
            IResultTypeConverter[] resultTypeConverters = new IResultTypeConverter[]
            {
                // Check if there is a particular converter for converting from TSourceResultType to TDestinationSourceResultType.
                installedResultTypeConverters.FirstOrDefault(c => c.SourceType == sourceType && c.DestinationType == typeof(TDestinationResultType)),
                // Check if there is a particular converter for converting from TSourceResultType to any enum type.
                installedResultTypeConverters.FirstOrDefault(c => c.SourceType == sourceType && c.DestinationType == null),
                // Check if there is a particular converter for converting from any enum type to TDestinationResultType. 
                installedResultTypeConverters.FirstOrDefault(c => c.SourceType == null && c.DestinationType == typeof(TDestinationResultType)),
                // Check if there is a particular converter for converting from any enum type to any enum type. 
                installedResultTypeConverters.FirstOrDefault(c => c.SourceType == null && c.DestinationType == null)
            }.Where(c => c != null).ToArray();

            if (!resultTypeConverters.Any())
            {
                throw new InvalidCastException($"No compatible converter was found for the source type {sourceType} and destination type {typeof(TDestinationResultType)}.");
            }

            foreach (IResultTypeConverter resultTypeConverter in resultTypeConverters)
            {
                Enum destinationValue = resultTypeConverter.Convert(sourceResultType, typeof(TDestinationResultType));
                // If the current converter returns null, continue onto the next converter. If not, return the value.
                if (destinationValue != null)
                {
                    return (TDestinationResultType) destinationValue;
                }
            }

            // If all of the converters return null, throw an exception. 
            throw new InvalidCastException($"Could not determine a suitable value of type {typeof(TDestinationResultType)} to convert the value \"{sourceResultType}\" of type {sourceResultType.GetType()} to. " +
                                           $"Please ensure that either the source or destination values are annotated with appropriate \"ResultType\" attributes, or implement a custom converter.");
        }
    }
}
