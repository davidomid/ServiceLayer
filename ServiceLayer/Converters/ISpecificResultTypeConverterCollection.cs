using System;
using System.Collections.Generic;

namespace ServiceLayer.Converters
{
    public interface ISpecificResultTypeConverterCollection
    {
        IReadOnlyCollection<IConvertToResultType> GetAll();
        IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>(Type sourceResultType) where TDestinationResultType : struct, Enum;
        IResultTypeConverter<TSourceResultType, TDestinationResultType> Get<TSourceResultType, TDestinationResultType>() where TSourceResultType : struct, Enum where TDestinationResultType : struct, Enum;
        void AddOrReplace<TSourceResultType, TDestinationResultType>(IResultTypeConverter<TSourceResultType, TDestinationResultType> resultTypeConverter) where TSourceResultType : struct, Enum where TDestinationResultType : struct, Enum;
        void Remove<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum;
    }
}
