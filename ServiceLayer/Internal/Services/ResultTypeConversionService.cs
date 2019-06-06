using System;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Services
{
    internal class ResultTypeConversionService : IResultTypeConversionService
    {
        public TDestinationResultType Convert<TDestinationResultType>(Enum sourceResultType)
            where TDestinationResultType : struct, Enum
        {
            Type sourceType = sourceResultType.GetType();

            // Check if there is a particular converter for converting from TSourceResultType to TDestinationSourceResultType.
            IResultTypeConverter resultTypeConverter =
                ServiceLayerConfiguration.ResultTypeConverters.Get(sourceType, typeof(TDestinationResultType))
                // Check if there is a particular converter for converting from TSourceResultType to any enum type.
                ?? ServiceLayerConfiguration.ResultTypeConverters.Get(sourceType, null)
                // Check if there is a particular converter for converting from any enum type to TDestinationResultType. 
                ?? ServiceLayerConfiguration.ResultTypeConverters.Get(null, typeof(TDestinationResultType))
                // Check if there is a particular converter for converting from any enum type to any enum type. 
                ?? ServiceLayerConfiguration.ResultTypeConverters.Get(null, null); 

            if (resultTypeConverter == null)
            {
                throw new InvalidCastException($"No compatible converter was found for the source type {sourceType} and destination type {typeof(TDestinationResultType)}.");
            }

            return (TDestinationResultType) resultTypeConverter.Convert(sourceResultType,
                typeof(TDestinationResultType));
        }
    }
}
