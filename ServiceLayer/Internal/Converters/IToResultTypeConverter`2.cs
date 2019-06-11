using System;

namespace ServiceLayer.Internal.Converters
{
    internal interface IOneToOneResultTypeConverter<TSourceResultType, TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
        where TSourceResultType : struct, Enum
    {
        TDestinationResultType? Convert(TSourceResultType sourceResultType);
    }
}
