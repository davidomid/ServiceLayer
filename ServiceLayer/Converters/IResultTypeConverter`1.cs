using System;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter<TDestinationResultType> : IResultTypeConverter where TDestinationResultType : Enum
    {
        TDestinationResultType Convert(Enum enumValue);
    }
}
