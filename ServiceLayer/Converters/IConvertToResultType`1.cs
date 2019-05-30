using System;

namespace ServiceLayer.Converters
{
    public interface IConvertToResultType<TDestinationResultType>
        where TDestinationResultType : struct, Enum
    {
        TDestinationResultType Convert(Enum sourceResultType);
    }
}
