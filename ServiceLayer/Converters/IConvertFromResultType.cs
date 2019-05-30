using System;

namespace ServiceLayer.Converters
{
    internal interface IConvertFromResultType<TSourceResultType> : IResultTypeConverter where TSourceResultType : struct, Enum
    {
        TDestinationResultType Convert<TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum;
    }
}
