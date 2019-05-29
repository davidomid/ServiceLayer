using System;
namespace ServiceLayer.Converters
{
    public interface IResultTypeConverter<TSourceResultType, TDestinationResultType> : IResultTypeConverter<TDestinationResultType> 
        where TSourceResultType : Enum 
        where TDestinationResultType : struct, Enum
    {
        TDestinationResultType? Convert(TSourceResultType sourceResultType);
    }
}
