using System;

namespace ServiceLayer.Converters
{
    public interface IConvertToResultType<TDestinationResultType, TSourceResultType>
        where TDestinationResultType : struct, Enum
        where TSourceResultType : struct, Enum
    {
        TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
