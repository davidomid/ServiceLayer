﻿using System;
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
                ?? ServiceLayerConfiguration.ResultTypeConverters.Get(sourceType, null) 
                ?? ServiceLayerConfiguration.ResultTypeConverters.Get(null, typeof(TDestinationResultType));

            if (resultTypeConverter == null)
            {
                throw new InvalidCastException($"No compatible converter was found for the source type {sourceType} and destination type {typeof(TDestinationResultType)}.");
            }

            return (TDestinationResultType) resultTypeConverter.Convert(sourceResultType,
                typeof(TDestinationResultType));
        }
    }
}