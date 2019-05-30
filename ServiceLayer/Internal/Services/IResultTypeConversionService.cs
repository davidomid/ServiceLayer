using System;

namespace ServiceLayer.Internal.Services
{
    internal interface IResultTypeConversionService
    {
        TDestinationResultType Convert<TSourceResultType, TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum;
    }
}
