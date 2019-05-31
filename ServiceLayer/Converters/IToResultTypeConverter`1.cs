using System;

namespace ServiceLayer.Converters
{
    public interface IToResultTypeConverter<TDestinationResultType> : IResultTypeConverter
        where TDestinationResultType : struct, Enum
    {
        new TDestinationResultType Convert(Enum sourceResultType);
    }
}
