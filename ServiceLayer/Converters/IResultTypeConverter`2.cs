using System;
namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter<TSourceResultType, TDestinationResultType> : IResultTypeConverter where TSourceResultType : Enum where TDestinationResultType : Enum
    {
        TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
