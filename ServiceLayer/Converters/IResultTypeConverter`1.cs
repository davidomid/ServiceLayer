using System;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter<TResultType> : IConvertToResultType where TResultType : struct, Enum
    {
        TResultType? Convert(Enum enumValue);
        TDestinationResultType? Convert<TDestinationResultType>(TResultType resultType) where TDestinationResultType : struct, Enum;
    }
}
