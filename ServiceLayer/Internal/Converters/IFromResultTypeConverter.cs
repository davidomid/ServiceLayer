using System;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal interface IFromResultTypeConverter<TSourceResultType> : IResultTypeConverter where TSourceResultType : struct, Enum
    {
    }
}
