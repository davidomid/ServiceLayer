using System;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal interface IOneToOneResultTypeConverter<TDestinationResultType, TSourceResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
        where TSourceResultType : struct, Enum
    {
        TDestinationResultType? Convert(TSourceResultType sourceResultType);
    }
}
