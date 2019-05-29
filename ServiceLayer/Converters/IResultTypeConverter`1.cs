using System;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter<TResultType> : IResultTypeConverter where TResultType : struct, Enum
    {
        TResultType? Convert(Enum enumValue);
        TDestinationResultType? Convert<TDestinationResultType>(TResultType resultType) where TDestinationResultType : struct, Enum;
    }
}
