using System;

namespace ServiceLayer.Converters
{
    public interface IConvertToResultType<TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
    {
        TDestinationResultType Convert(Enum sourceResultType);
    }
}
