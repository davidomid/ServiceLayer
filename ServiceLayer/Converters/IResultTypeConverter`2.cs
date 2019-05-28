using System;
namespace ServiceLayer.Converters
{
    internal interface IResultTypeConverter<TSourceResultType, TDestinationResultType> : IResultTypeConverter where TSourceResultType : Enum where TDestinationResultType : Enum
    {
        TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
