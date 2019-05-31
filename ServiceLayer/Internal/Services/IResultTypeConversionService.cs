using System;

namespace ServiceLayer.Internal.Services
{
    internal interface IResultTypeConversionService
    {
        TDestinationResultType Convert<TDestinationResultType>(Enum sourceResultType)
            where TDestinationResultType : struct, Enum;
    }
}
