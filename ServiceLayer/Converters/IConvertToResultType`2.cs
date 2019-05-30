using System;

namespace ServiceLayer.Converters
{
    public interface IConvertToResultType<TDestinationResultType, TSourceResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
        where TSourceResultType : struct, Enum
    {
        TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
