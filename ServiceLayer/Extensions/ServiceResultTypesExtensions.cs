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
            return ServiceLayerConfiguration.ResultTypeConversionService.Convert<TDestinationResultType>(resultType);
        }
    }
}
