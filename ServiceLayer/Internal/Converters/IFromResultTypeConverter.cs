using System;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal interface IFromResultTypeConverter<TSourceResultType> : IResultTypeConverter where TSourceResultType : Enum
    {
        TDestinationResultType? Convert<TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum;
    }
}
