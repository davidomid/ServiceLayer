using System;

namespace ServiceLayer.Internal.Converters
{
    internal interface IAnyToOneResultConverter<TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
    {
        TDestinationResultType? Convert(Enum sourceResultType);
    }
}
