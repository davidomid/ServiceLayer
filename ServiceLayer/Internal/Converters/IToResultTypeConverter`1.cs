using System;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal interface IToResultTypeConverter<TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
    {
        new TDestinationResultType Convert(Enum sourceResultType);
    }
}
