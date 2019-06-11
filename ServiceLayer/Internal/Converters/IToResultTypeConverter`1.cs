using System;
using ServiceLayer;

namespace ServiceLayer.Internal.Converters
{
    internal interface IAnyToOneResultConverter<TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
    {
        TDestinationResultType? Convert(Enum sourceResultType);
    }
}
