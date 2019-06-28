using System;

namespace ServiceLayer.Internal.Converters
{
    internal interface IAnyToOneResultTypeConverter<TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
    {
        TDestinationResultType? Convert(Enum sourceResultType);
    }
}
