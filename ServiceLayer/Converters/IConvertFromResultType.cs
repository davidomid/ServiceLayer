using System;

namespace ServiceLayer.Converters
{
    public interface IConvertFromResultType<TSourceResultType> where TSourceResultType : struct, Enum
    {
        TDestinationResultType Convert<TDestinationResultType>(TSourceResultType sourceResultType);
    }
}
