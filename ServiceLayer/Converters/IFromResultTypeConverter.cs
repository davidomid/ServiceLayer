using System;

namespace ServiceLayer.Converters
{
    internal interface IFromResultTypeConverter<TSourceResultType> : IResultTypeConverter where TSourceResultType : struct, Enum
    {
        Enum Convert(TSourceResultType sourceResultType);
    }
}
