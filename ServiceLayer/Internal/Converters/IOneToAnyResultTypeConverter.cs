using System;

namespace ServiceLayer.Internal.Converters
{
    internal interface IOneToAnyResultTypeConverter<TSourceResultType> : IResultTypeConverter where TSourceResultType : Enum
    {
        TDestinationResultType? Convert<TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum;
    }
}
