using System;
namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter<TSourceResultType, TDestinationResultType> : IResultTypeConverter<TDestinationResultType> where TSourceResultType : Enum where TDestinationResultType : Enum
    {
        TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
