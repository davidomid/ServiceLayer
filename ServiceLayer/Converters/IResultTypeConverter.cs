using System;

namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter
    {
        Type SourceType { get; }
        Type DestinationType { get; }

        TDestinationResultType? Convert<TDestinationResultType>(Enum sourceResultType)
            where TDestinationResultType : struct, Enum;
    }
}
