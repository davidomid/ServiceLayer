using System;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public static class ServiceResultTypesExtensions
    {
        public static TDestinationResultType ToResultType<TDestinationResultType>(this Enum resultType) where TDestinationResultType : struct, Enum
        {
            return Engine.ResultTypeConversionService.Convert<TDestinationResultType>(resultType);
        }
    }
}
